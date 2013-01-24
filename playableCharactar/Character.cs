using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// プレイヤーから操作できるキャラクター
/// </summary>
public class Character : BaseCharacter {

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
        if (parameter.damage != null)
        {
            parameter.damage = damage.AddDamage(parameter.damage);
            return new CharacterHitStopState(this, parent.gamepad, parameter.damage);
        }
        parameter.damage = damage;
        return new CharacterHitStopState(this, parent.gamepad, parameter.damage);
    }
	virtual protected IState CreateDamageState(DamageParameter damage) { return new CharacterDamageState(this, damage); }
    virtual protected IState CreateBlowState() { return new CharacterBlowState(this); }
    virtual protected IState CreateChargeBlowState() { return new CharacterChargeBlowState(this); }
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
            weight = new Weight
            {
                quantity = parameterList.weight
            },
            stamina = new Stamina
            {
                quantity = 100F,
                recoveryRate = parameterList.staminaRecoverySpeed
            },
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
        parent.gamepad.Update();

        Type newState = state.Update();

        if (newState != null)
        {
            Debug.Log(newState);
            state = ChangeState(newState);
        }
        baseParameter.Update();
        parameter.Update();

        ParameterCheckOnState();

        CheckMaps();
    }

	virtual protected IState ChangeState(Type newState)
	{
        if (newState == typeof(CharacterStayState)) return CreateStayState();
        if (newState == typeof(CharacterMoveState)) return CreateMoveState();
        if (newState == typeof(CharacterDashMoveState)) return CreateDashState();
        if (newState == typeof(CharacterChargeState)) return CreateChargeState(parent.gamepad.GetChargeButton);
        if (newState == typeof(CharacterFallState)) return CreateFallState();
        if (newState == typeof(CharacterDeadState)) return CreateDeadState();
        if (newState == typeof(CharacterDamageState)) return CreateDamageState(parameter.damage.damageParameter);
        if (newState == typeof(CharacterBlowState)) return CreateBlowState();
        if (newState == typeof(CharacterChargeBlowState)) return CreateChargeBlowState();
        if (newState == typeof(CharacterSkillState)) return CreateSkillState();
        if (newState == typeof(CharacterChargeSkillState)) return CreateChargeSkillState();
        
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
        state = CreateHitStopState(damage);
	}
	
	public void ChangeFallState()
	{
        state = CreateFallState();
	}
	
	public void MovePosition(CharacterMoveState.MoveFix fix)
	{
		var fixVelocity = Weight.CalculateVelocityByWeight(baseParameter.moveParameter,
																parameter.weight) * fix.quantity;
		transform.localPosition += fixVelocity;
	}
	
	protected void ParameterCheckOnState()
	{
		if(!(state is CharacterChargeState))
		{
            parameter.attackCharge.Clear();
            parameter.skillCharge.Clear();
		}
		
		if(state is CharacterFallState)
		{
			//collider.enabled = false;
		}
		if(state is CharacterDeadState)
		{
            gameObject.SetActive(false);

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
        //マップの範囲外にいたら落下
        bool isInside = baseParameter.mapPosition.SetChipPositionByScreenPosition(transform.localPosition);
        if (!isInside) { ChangeFallState(); return;}

        //乗っているマップがnullもしくは壊れているなら落下
        var onMapChip = mapManager.GetMapChip(baseParameter.mapPosition);
        if (onMapChip == null || !onMapChip.isLive) { ChangeFallState(); return; }

        //乗っているマップにダメージを与える
        onMapChip.SetDamage(0.5F);
    }

    private void OnTriggerStay(Collider other)
    {
        if (IsCheckSameTeam(other)) return;
    }
}