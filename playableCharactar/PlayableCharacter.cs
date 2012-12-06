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
		
		parameter = new CharacterParameter();
		parameter.weight = new Weight{
			quantity = 25F
		};
		parameter.stamina = new Stamina{
			quantity = 100F,
			recoveryRate = 0.2F
		};
	}
	
	// Update is called once per frame
	void Update () {
		
		parent.gamepad.Update();
		
		IState newState = state.Update();
		
		if(newState != null)ChangeState(newState);
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
}