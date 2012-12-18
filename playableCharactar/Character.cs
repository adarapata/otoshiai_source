using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// プレイヤーから操作できるキャラクター
/// </summary>
public class Character : BaseCharacter {
	
	public IObjectOperator parent
	{
		get;
		set;
	}
	
	public CharacterParameter parameter
	{
		get;
		set;
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

    // Use this for initialization
	void Start () {
		// 本来はここで設定しないがまだPlayerクラスがあまりできてないからここで作成する
		parent = new PlayerOfHuman();
		parent.operationObject = this;
	
		state = new CharacterStayState(this, parent.gamepad);
		baseParameter = new BaseParameter();
		baseParameter.moveParameter = new MoveParameter(45,1F);
		
		animation = new CharacterAnimationController(sprite);
		
		InitParameter();
	}
	private void InitParameter()
	{
        parameter = new CharacterParameter
        {
            weight = new Weight
            {
                quantity = 25F
            },
            stamina = new Stamina
            {
                quantity = 100F,
                recoveryRate = 0.2F
            },
            diffence = new Diffence
            {
                quantity = 1.0F
            },
            attackCharge = new Charge(1F),
            skillCharge = new Charge(0.5F)
        };
	}
	// Update is called once per frame
	void Update () {
		
		parent.gamepad.Update();
		
		Type newState = state.Update();

        if (newState != null)
        {
           state = ChangeState(newState);
        }
		ParameterCheckOnState();
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
	
	
	public void ChangeHitState(Damage damage)
	{
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
	
	private void ParameterCheckOnState()
	{
		if(!(state is CharacterChargeState))
		{

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
}