using UnityEngine;
using System.Collections;

/// <summary>
/// プレイアブルキャラクターの移動状態クラス
/// </summary>
public class PlayableCharaMoveState : MoveState
{
	private IGamePad gamepad;
	private CharacterAnimationController animation;
	public PlayableCharaMoveState(BaseCharacter parent, IGamePad pad):base(parent)
	{
		gamepad = pad;
		animation = stateParent.animation as CharacterAnimationController;
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
			stateParent.state = new PlayableCharaStayState(stateParent as PlayableCharacter, gamepad);
			return;
		}
		
		stateParent.baseParameter.moveParameter.direction = (int)st;
		animation.SetPatternByStick(st);
	}
}

