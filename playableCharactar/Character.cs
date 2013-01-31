using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// �v���C���[���瑀��ł���L�����N�^�[
/// </summary>
public class Character : BaseCharacter {

    /// <summary>
    /// �����p�����[�^
    /// </summary>
    public ParameterList parameterList;

    /// <summary>
    /// ���쌳�̃v���C���[
    /// </summary>
	public IObjectOperator parent
	{
		get;
		set;
	}
	
    /// <summary>
    /// �p�����[�^
    /// </summary>
	public CharacterParameter parameter
	{
		get;
		set;
	}

    /// <summary>
    /// �p�����[�^�E�B���h�E
    /// </summary>
    public CharacterParameterWindow parameterWindow
    {
        get;
        set;
    }
    /// <summary>
    /// �}�b�v�f�[�^
    /// </summary>
    protected MapManager mapManager;

    /// <summary>
    /// �L�����N�^�[�̌����Ă������Ԃ�
    /// </summary>
    public int frontDirection
    {
        get { return (animation as CharacterAnimationController).frontDirection; }
    }

    #region State���\�b�h�Q
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
        //�ڂ̑O�ɔ�������ꍇ�A�U�������ɔ�������
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
    /// �O���̃I�u�W�F�N�g���Q�Ƃ���f�[�^�̏�����
    /// </summary>
	protected void InitData()
	{
        mapManager = GameObject.Find("map_manager").GetComponent<MapManager>();

        state = new CharacterStayState(this, parent.gamepad);


        animation = new CharacterAnimationController(sprite);

        //�`�[���ݒ�
        baseParameter.team = new Team(parent.team.name);
        //�����|�W�V�����ݒ�
        baseParameter.mapPosition = mapManager.mapParameter.GetFirstPosition(parent.number);

        var screenPos = baseParameter.mapPosition.GetScreenPositionByMapPosition();
        transform.localPosition = new Vector3(screenPos.x,
                                                screenPos.y,
                                                  transform.localPosition.z);
	}

    /// <summary>
    /// �p�����[�^�̏�����
    /// </summary>
    /// <param name="_weight"></param>
    /// <param name="_recoveryRate"></param>
    /// <param name="_diffence"></param>
    /// <param name="_attackCh"></param>
    /// <param name="_skillCh"></param>
    /// <param name="_speed"></param>
    protected void InitCharacterParameter()
    {
        #region �p�����[�^�ݒ�
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

        Type newState = state.Update();

        if (newState != null)
        {
            //Debug.Log(newState);
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
    /// Hit��ԂɈڍs������
    /// </summary>
    /// <param name="damage"></param>
	public void ChangeHitState(Damage damage)
	{
        //���G��ԂȂ�󂯕t���Ȃ�
        if (parameter.invincibly.flag) return;

        //���ł�HitStop��ԂȂ�AHitStop���d�˂���
        if (state is CharacterHitStopState)
        {
            parameter.damage = damage.AddDamage(parameter.damage);
            return;
        }
        state = CreateHitStopState(damage);
	}
	
	public void ChangeFallState()
	{
        //���S�y�ї������Ȃ牽�����Ȃ�
        if (state is CharacterFallState) return;
        if (state is CharacterDeadState) return;
        state = CreateFallState();
        SoundManager.Play(SoundManager.fall);
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
			collider.enabled = false;
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
    /// �}�b�v�𒲂ׂė�������̃`�F�b�N
    /// </summary>
    protected void CheckMaps()
    {
        //�}�b�v�͈̔͊O�ɂ����痎��
        bool isInside = baseParameter.mapPosition.SetChipPositionByScreenPosition(transform.localPosition);
        if (!isInside) { ChangeFallState(); return;}

        //����Ă���}�b�v��null�������͉��Ă���Ȃ痎��
        var onMapChip = mapManager.GetMapChip(baseParameter.mapPosition);
        if (onMapChip == null || !onMapChip.isLive) { ChangeFallState(); return; }

        //����Ă���}�b�v�Ƀ_���[�W��^����
        onMapChip.SetDamage(parameter.weight.DamageToMapChip());
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }
    void OnTriggerStay(Collider other)
    {
        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy is BaseBox) CheckColliedingBox(enemy as BaseBox);
    }

    virtual protected void ColliedCheck(Collider other)
    {
        if (IsCheckSameTeam(other)) return;

        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy is Character) CheckColliedByCharacter(enemy as Character);
    }

    protected void CheckColliedByCharacter(Character enemy)
    {
        if (state is CharacterDamageState)
        {
            var d = parameter.damage;
            Damage damageToEnemy = new Damage(10, false, d.damageParameter.damage, d.damageParameter.direction, false);
            enemy.ChangeHitState(damageToEnemy);
            d.damageParameter.damage = 1;
        }
    }

    /// <summary>
    /// ���ɐڐG�����ꍇ�̏���
    /// </summary>
    /// <param name="box"></param>
    protected void CheckColliedingBox(BaseBox box)
    {
        if (state is CharacterDamageState) 
        {
            box.Crash();
            parameter.damage.damageParameter.damage = 1;
            return;
        }

        //�p�x���߂�
        Vector2 fix = transform.localPosition - box.transform.localPosition;
        int angleA = (int)Vector2.Angle(Vector2.one, fix);
        int angleB = (int)Vector2.Angle(new Vector2(-1, 1), fix);
        bool x, y;
        x = angleA > 0 & angleA <= 90;
        y = angleB > 0 & angleB <= 90;

        Vector3 pos = transform.localPosition;
        Vector2 boxis = box.transform.localPosition;

        if (x)
        {
            if(y) pos.y = boxis.y + 16 + 10;
            else pos.x = boxis.x + 16 + 6;
        }
        else 
        {
            if (y) pos.x = boxis.x - 16 - 6;
            else pos.y = boxis.y - 16 - 10;
        }

        transform.localPosition = pos;
    }

    /// <summary>
    /// �����̌����Ă������Box����������Ԃ��B
    /// </summary>
    /// <returns></returns>
    protected BaseBox GetNearBox()
    {
        Ray r = new Ray(transform.position, PolarCoordinates.ConvertToPolar(frontDirection, 1F));
        RaycastHit h = new RaycastHit();
        if (Physics.Raycast(r, out h, 0.05F)) 
        {
            var script = h.collider.gameObject.GetComponent<BaseBox>();
            return script is BaseBox ? script : null;
        }

        return null;
    }

    /// <summary>
    /// �����������ԂȂ牟���B����������true
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