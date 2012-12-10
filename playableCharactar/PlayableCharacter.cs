using UnityEngine;
using System.Collections;

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
		
		IState newState = state.Update();
		
		if(newState != null)ChangeState(newState);
		
		ParameterCheckOnState();
	}
	
	virtual protected void ChangeState(IState newState)
	{
		state = newState;
	}
	
	public void ChangeHitState()
	{
		
	}
	
	public void ChangeFallState()
	{
		ChangeState(new PlayableCharacterFallState(this));
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