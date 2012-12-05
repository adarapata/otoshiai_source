using UnityEngine;
using System.Collections;

/// <summary>
/// プレイアブルキャラクターの移動状態クラス
/// </summary>
public class PlayableCharacterMoveState : PlayableCharacterBaseState
{
	private IGamePad gamepad;
	private CharacterAnimationController animation;
	private FrameCounter framecounter;
	
	public PlayableCharacterMoveState(PlayableCharacter parent, IGamePad pad):base(parent)
	{
		framecounter = new FrameCounter(8);
		gamepad = pad;
		animation = stateParent.animation as CharacterAnimationController;
	}
	
	public override IState Update()
	{
		IState newState = CheckOfKey();
		
		Move();
		
		StaminaRecover();
		
		AnimationFrameUpdate();
		
		return newState;
	}
	
	private IState CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(st == Stick.None)return new PlayableCharacterStayState(character, gamepad);
		
		stateParent.baseParameter.moveParameter.direction = (int)st;
		animation.SetPatternByStick(st);
		
		if(gamepad.IsPush(Button.D) && PlayableCharacterDashMoveState.IsParmittion(parameter.stamina))
			return new PlayableCharacterDashMoveState(character, gamepad);
		
		return null;
	}
	
	private void Move()
	{
		var fixVelocity = Weight.CalculateVelocityByWeight(stateParent.baseParameter.moveParameter,
																parameter.weight);
		stateParent.transform.localPosition += fixVelocity;
	}
	
	private void StaminaRecover()
	{
		parameter.stamina.Recovery();
	}
	
	private void AnimationFrameUpdate()
	{
		framecounter.Update();
		if(framecounter.IsCall)animation.ChangeFrame(true);
	}
}

