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
		
		ParameterCheck();
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
		
	}
	
	public void MovePosition(float fix)
	{
		var fixVelocity = Weight.CalculateVelocityByWeight(baseParameter.moveParameter,
																parameter.weight) * fix;
		transform.localPosition += fixVelocity;
	}
	
	private void ParameterCheck()
	{
		if(!(state is PlayableCharacterChargeState))
		{
			parameter.charge.Clear();
		}
	}
}