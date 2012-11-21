using UnityEngine;
using System.Collections;

public class PlayableCharaDashMoveState : PlayableCharaBaseState
{
	const float CONSUMPTION = 2F;
	
	private IGamePad gamepad;
	private CharacterAnimationController animation;
	public PlayableCharaDashMoveState(PlayableCharacter parent, IGamePad pad):base(parent)
	{
		gamepad = pad;
		animation = stateParent.animation as CharacterAnimationController;
	}
	
	public override void Update()
	{
		CheckOfKey();
		
		DashMove();
		
		StaminaUse();
		
		
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
		
		if(!gamepad.IsPush(Button.D) || parameter.stamina.quantity < CONSUMPTION)stateParent.state = new PlayableCharaMoveState(character, gamepad);
	}
	
	private void DashMove()
	{
		var fixVelocity = Weight.CalculateVelocityByWeight(stateParent.baseParameter.moveParameter,
																parameter.weight) * 2F;
		stateParent.transform.localPosition += fixVelocity;
	}
	
	private void StaminaUse()
	{
		parameter.stamina.quantity -= CONSUMPTION;
	}
	
}

