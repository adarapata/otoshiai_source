using UnityEngine;
using System.Collections;

/// <summary>
/// プレイアブルキャラクターの移動状態クラス
/// </summary>
public class PlayableCharaMoveState : PlayableCharaBaseState
{
	private IGamePad gamepad;
	private CharacterAnimationController animation;
	public PlayableCharaMoveState(PlayableCharacter parent, IGamePad pad):base(parent)
	{
		gamepad = pad;
		animation = stateParent.animation as CharacterAnimationController;
	}
	
	public override void Update()
	{
		CheckOfKey();
		var fixVelocity = Weight.CalculateVelocityByWeight(stateParent.baseParameter.moveParameter,
																parameter.weight);
		stateParent.transform.localPosition += fixVelocity;
	}
	
	
	
	private void CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(st == Stick.None)
		{
			stateParent.state = new PlayableCharaStayState(character, gamepad);
			return;
		}
		
		stateParent.baseParameter.moveParameter.direction = (int)st;
		animation.SetPatternByStick(st);
	}
}

