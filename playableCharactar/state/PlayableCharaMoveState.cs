using UnityEngine;
using System.Collections;

/// <summary>
/// プレイアブルキャラクターの移動状態クラス
/// </summary>
public class PlayableCharaMoveState : MoveState
{
	private IGamePad gamepad;
	private PlayableCharaAnimationController animation;
	public PlayableCharaMoveState(BaseCharactar parent, IGamePad pad):base(parent)
	{
		gamepad = pad;
		animation = stateParent.animation as PlayableCharaAnimationController;
	}
	
	public override void Update()
	{
		CheckOfKey();
		base.Update();
	}
	
	private void CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(st == Stick.None)
		{
			stateParent.state = new PlayableCharaStayState(stateParent as PlayableCharactar, gamepad);
			return;
		}
		
		stateParent.baseParameter.moveParameter.direction = (int)st;
		animation.SetPatternByStick(st);
	}
}

