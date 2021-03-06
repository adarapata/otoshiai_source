using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// プレイヤーから操作できるキャラクター
/// </summary>
public partial class Character : BaseCharacter {

    public override OBJECTTYPE Type
    {
        get
        {
            return OBJECTTYPE.Character;
        }
    }
    /// <summary>
    /// Characterが持つ状態の列挙体
    /// </summary>
    public enum STATENAME : int
    {
        Stay = 0,
        Blow,
        ChargeBlow,
        ChargeSkill,
        Charge,
        Damage,
        DashMove,
        Dead,
        Fall,
        HitStop,
        Move,
        Skill,
        /// <summary>
        /// 変更しない
        /// </summary>
        Changeless = GENERICSTATENAME.Changeless
    }

    /// <summary>
    /// 初期パラメータ
    /// </summary>
    public ParameterList parameterList;

    /// <summary>
    /// 操作元のプレイヤー
    /// </summary>
	public IObjectOperator parent
	{
		get;
		set;
	}
	
    /// <summary>
    /// パラメータ
    /// </summary>
	public CharacterParameter parameter
	{
		get;
		set;
	}

    /// <summary>
    /// パラメータウィンドウ
    /// </summary>
    public CharacterParameterWindow parameterWindow
    {
        get;
        set;
    }
    /// <summary>
    /// マップデータ
    /// </summary>
    protected MapManager mapManager;

    /// <summary>
    /// キャラクターの向いてる方向を返す
    /// </summary>
    public int frontDirection
    {
        get { return (animation as CharacterAnimationController).frontDirection; }
    }

    #region Stateメソッド群
    virtual protected IState CreateStayState() { return new CharacterStayState(this, parent.gamepad); }
	virtual protected IState CreateMoveState() { return new CharacterMoveState(this, parent.gamepad); }
	virtual protected IState CreateDashState() { return new CharacterDashMoveState(this, parent.gamepad); }
	virtual protected IState CreateChargeState(string push) { return new CharacterChargeState(this, parent.gamepad, push); } 
	virtual protected IState CreateFallState() { return new CharacterFallState(this); }
	virtual protected IState CreateDeadState() { return new CharacterDeadState(this); }
    virtual protected IState CreateHitStopState(Damage damage) {
        parameter.damage = damage;
        return new CharacterHitStopState(this, parent.gamepad, parameter.damage);
    }
	virtual protected IState CreateDamageState(DamageParameter damage) { return new CharacterDamageState(this, damage); }
    virtual protected IState CreateBlowState() 
    {
        //目の前に箱がある場合、攻撃せずに箱を押す
        if (CheckPutBox(parameter.power.quantity / 2)) return CreateStayState();
        return new CharacterBlowState(this); 
    }
    virtual protected IState CreateChargeBlowState()
    {
        if (CheckPutBox(parameter.power.quantity)) return CreateStayState();
        return new CharacterChargeBlowState(this); 
    }
    virtual protected IState CreateSkillState() { return new CharacterSkillState(this); }
    virtual protected IState CreateChargeSkillState() { return new CharacterChargeSkillState(this); }
    #endregion

    void Awake()
    {
        InitCharacterParameter();
    }
    // Use this for initialization
	void Start () {
        InitData();
	}

    /// <summary>
    /// 外部のオブジェクトを参照するデータの初期化
    /// </summary>
	protected void InitData()
	{
        mapManager = GameObject.Find("map_manager").GetComponent<MapManager>();

        state = new CharacterStayState(this, parent.gamepad);


        animation = new CharacterAnimationController(sprite);

        //チーム設定
        baseParameter.team = new Team(parent.team.name);
        //初期ポジション設定
        baseParameter.mapPosition = mapManager.mapParameter.GetFirstPosition(parent.number);

        var screenPos = baseParameter.mapPosition.GetScreenPositionByMapPosition();
        transform.localPosition = new Vector3(screenPos.x,
                                                screenPos.y,
                                                  transform.localPosition.z);
	}

    /// <summary>
    /// パラメータの初期化
    /// </summary>
    /// <param name="_weight"></param>
    /// <param name="_recoveryRate"></param>
    /// <param name="_diffence"></param>
    /// <param name="_attackCh"></param>
    /// <param name="_skillCh"></param>
    /// <param name="_speed"></param>
    protected void InitCharacterParameter()
    {
        #region パラメータ設定
        parameter = new CharacterParameter
        {
            power = new Power { quantity = parameterList.power },

            weight = new Weight(parameterList.weight),

            stamina = new Stamina(parameterList.staminaRecoverySpeed),

            diffence = new Diffence
            {
                quantity = parameterList.deffence
            },
            attackCharge = new Charge(parameterList.blowChargeSpeed),
            skillCharge = new Charge(parameterList.skillChargeSpeed),
            invincibly = new Invincibly()
        };
        #endregion

        baseParameter = new BaseParameter(sprite);
        baseParameter.moveParameter = new MoveParameter(0, parameterList.speed);
    }
	
    // Update is called once per frame
	void Update () {
        ScriptUpdate();
	}

    virtual protected void ScriptUpdate()
    {
        if (MainGameParameter.instance.Pause) return;

        parent.gamepad.Update();

        var nextState = state.Update();

        if (nextState != (int)STATENAME.Changeless)
        {
            state = ChangeState((STATENAME)nextState);
        }
        baseParameter.Update();
        parameter.Update();

        ParameterCheckOnState();

        CheckMaps();
    }

	virtual protected IState ChangeState(STATENAME newState)
	{
        switch (newState)
        {
            case STATENAME.Stay:
                return CreateStayState();
            case STATENAME.Move:
                return CreateMoveState();
            case STATENAME.DashMove:
                return CreateDashState();
            case STATENAME.Charge:
                return CreateChargeState(parent.gamepad.GetChargeButton);
            case STATENAME.Blow:
                return CreateBlowState();
            case STATENAME.ChargeBlow:
                return CreateChargeBlowState();
            case STATENAME.Skill:
                return CreateSkillState();
            case STATENAME.ChargeSkill:
                return CreateChargeSkillState();
            case STATENAME.Damage:
                return CreateDamageState(parameter.damage.damageParameter);
            case STATENAME.Fall:
                return CreateFallState();
            case STATENAME.Dead:
                return CreateDeadState();
        }
        
        return null;
	}
	
    /// <summary>
    /// Hit状態に移行させる
    /// </summary>
    /// <param name="damage"></param>
	public void ChangeHitState(Damage damage)
	{
        //無敵状態なら受け付けない
        if (parameter.invincibly.flag) return;

        //すでにHitStop状態なら、HitStopを重ねがけ
        if (state.name == (int)STATENAME.HitStop)
        {
            parameter.damage = damage.AddDamage(parameter.damage);
            return;
        }
        state = CreateHitStopState(damage);
	}
	
	public void ChangeFallState()
	{
        //死亡及び落下中なら何もしない
        if (state.name == (int)STATENAME.Fall ||
            state.name == (int)STATENAME.Dead) return;


        state = CreateFallState();
        SoundManager.Play(SoundManager.fall);
	}
	
	public void MovePosition(MoveFix fix)
	{
		var fixVelocity = Weight.CalculateVelocityByWeight(baseParameter.moveParameter,
																parameter.weight) * fix.quantity;
		transform.localPosition += fixVelocity;
	}
	
	protected void ParameterCheckOnState()
	{
		if(state.name != (int)STATENAME.Charge)
		{
            parameter.attackCharge.Clear();
            parameter.skillCharge.Clear();
		}

        switch ((STATENAME)state.name)
        {
            case STATENAME.Fall:
                collider.enabled = false;
                break;
            case STATENAME.Dead:
                gameObject.SetActive(false);
                break;
        }

	}
	
	virtual protected void StayStateCheck()
	{
		
	}
	virtual protected void MoveStateCheck()
	{
        
	}

    /// <summary>
    /// マップを調べて落下判定のチェック
    /// </summary>
    protected void CheckMaps()
    {
        //死亡及び落下中なら何もしない
        if (state.name == (int)STATENAME.Fall ||
            state.name == (int)STATENAME.Dead) { return; }

        //マップの範囲外にいたら落下
        bool isInside = baseParameter.mapPosition.SetChipPositionByScreenPosition(transform.localPosition);
        if (!isInside) { ChangeFallState(); return;}

        //乗っているマップがnullもしくは壊れているなら落下
        var onMapChip = mapManager.GetMapChip(baseParameter.mapPosition);
        if (onMapChip == null || !onMapChip.isLive) { ChangeFallState(); return; }

        //乗っているマップにダメージを与える
        onMapChip.SetDamage(parameter.weight.DamageToMapChip());
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other.gameObject);
    }
    void OnTriggerStay(Collider other)
    {
        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy.Type == OBJECTTYPE.Box) CheckColliedingBox(enemy as BaseBox);
    }

    virtual protected void ColliedCheck(GameObject obj)
    {
        if (IsCheckSameTeam(obj.transform)) return;

        var enemy = obj.GetComponent<BaseCharacter>();
        if (enemy.Type == OBJECTTYPE.Character) CheckColliedByCharacter(enemy as Character);
    }

    /// <summary>
    /// キャラと衝突した場合の判定
    /// </summary>
    /// <param name="enemy"></param>
    protected void CheckColliedByCharacter(Character enemy)
    {
        if (state.name == (int)STATENAME.Damage)
        {
            var d = parameter.damage;
            Damage damageToEnemy = new Damage(10, false, d.damageParameter.damage, d.damageParameter.direction, false);
            enemy.ChangeHitState(damageToEnemy);
            d.damageParameter.damage = 1;
        }
    }

    /// <summary>
    /// 箱に接触した場合の処理
    /// </summary>
    /// <param name="box"></param>
    protected void CheckColliedingBox(BaseBox box)
    {
        if (state.name == (int)STATENAME.Damage) 
        {
            box.Crash();
            parameter.damage.damageParameter.damage = 1;
            return;
        }

        transform.localPosition = box.PositionFix(transform.localPosition);
    }

    /// <summary>
    /// 自分の向いてる方向にBoxがあったら返す。
    /// </summary>
    /// <returns></returns>
    protected BaseBox GetNearBox()
    {
        //向いてる方向のレイを作る
        Ray r = new Ray(transform.position, PolarCoordinates.ConvertToPolar(frontDirection, 1F));
        RaycastHit h = new RaycastHit();

        //目の前に箱があった場合
        if (Physics.Raycast(r, out h, 0.05F)) 
        {
            var script = h.collider.gameObject.GetComponent<BaseBox>();
            return script is BaseBox ? script : null;
        }

        return null;
    }

    /// <summary>
    /// 箱が押せる状態なら押す。成功したらtrue
    /// </summary>
    /// <param name="power"></param>
    /// <returns></returns>
    protected bool CheckPutBox(float power)
    {
        BaseBox near = GetNearBox();
        if (near != null)
        {
            near.Put(frontDirection, power);
            return true;
        }
        return false;
    }
}