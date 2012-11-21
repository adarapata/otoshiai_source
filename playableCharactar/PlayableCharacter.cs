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

		state = new PlayableCharaStayState(this, parent.gamepad);
		baseParameter = new BaseParameter();
		baseParameter.moveParameter = new MoveParameter(45,1F);
		
		animation = new CharacterAnimationController(sprite);
		
		parameter = new CharacterParameter();
		parameter.weight = new Weight{
			quantity = 25F
		};
		parameter.stamina = new Stamina{
			quantity = 100F,
			recoveryRate = 0.5F
		};
	}
	
	// Update is called once per frame
	void Update () {
		parent.gamepad.Update();
		state.Update();
	}
}