using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// プレイヤーから操作できるキャラクター
/// </summary>
public class PlayableCharacter : BaseCharacter {
	
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
    virtual protected IState CreateStayState() { return new PlayableCharacterStayState(this, parent.gamepad); }
	virtual protected IState CreateMoveState() { return new PlayableCharacterMoveState(this, parent.gamepad); }
	virtual protected IState CreateDashState() { return new PlayableCharacterDashMoveState(this, parent.gamepad); }
	virtual protected IState CreateChargeState(string push) { return new PlayableCharacterChargeState(this, parent.gamepad, push); } 
	virtual protected IState CreateFallState() { return new PlayableCharacterFallState(this); }
	virtual protected IState CreateDeadState() { return new PlayableCharacterDeadState(this); }
	virtual protected IState CreateHitStopState(Damage damage) { return new PlayableCharacterHitStopState(this, parent.gamepad, damage); }
	virtual protected IState CreateDamageState(DamageParameter damage) { return new PlayableCharacterDamageState(this, damage); }
    #endregion

    // Use this for initialization
	void Start () {
		// 本来はここで設定しないがまだPlayerクラスがあまりできてないからここで作成する
		parent = new PlayerOfHuman();
		parent.operationObject = this;
	
		state = new PlayableCharacterStayState(this, parent.gamepad);
		baseParameter = new BaseParameter();
		baseParameter.moveParameter = new MoveParameter(45,1F);
		
		animation = new CharacterAnimationController(sprite);
		
		InitParameter();
	}
	private void InitParameter()
	{
		parameter = new CharacterParameter();
		parameter.weight = new Weight{
			quantity = 25F
		};
		parameter.stamina = new Stamina{
			quantity = 100F,
			recoveryRate = 0.2F
		};
		
		parameter.charge = new Charge{
			speed = 0.1F	
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
        if (newState == typeof(PlayableCharacterStayState)) return CreateStayState();
        if (newState == typeof(PlayableCharacterMoveState)) return CreateMoveState();
        if (newState == typeof(PlayableCharacterDashMoveState)) return CreateDashState();
        if (newState == typeof(PlayableCharacterChargeState)) return CreateChargeState(Button.A);
        if (newState == typeof(PlayableCharacterFallState)) return CreateFallState();
        if (newState == typeof(PlayableCharacterDeadState)) return CreateDeadState();

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
	
	public void MovePosition(PlayableCharacterMoveState.MoveFix fix)
	{
		var fixVelocity = Weight.CalculateVelocityByWeight(baseParameter.moveParameter,
																parameter.weight) * fix.quantity;
		transform.localPosition += fixVelocity;
	}
	
	private void ParameterCheckOnState()
	{
		if(!(state is PlayableCharacterChargeState))
		{
			parameter.charge.Clear();
		}
		
		if(state is PlayableCharacterFallState)
		{
			//collider.enabled = false;
		}
		if(state is PlayableCharacterDeadState)
		{
			gameObject.active = false;

		}
	}
	
	virtual protected void StayStateCheck()
	{
		
	}
	virtual protected void MoveStateCheck()
	{
		
	}
}