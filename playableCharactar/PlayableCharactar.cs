using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーから操作できるキャラクター
/// </summary>
public class PlayableCharactar : BaseCharactar {
	
	public IObjectOperator parent
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
		
		animation = new PlayableCharaAnimationController(sprite);
	}
	
	// Update is called once per frame
	void Update () {
		parent.gamepad.Update();
		state.Update();
	}
}