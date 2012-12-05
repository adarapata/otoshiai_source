using UnityEngine;
using System.Collections;

public class PlayableCharacterDashMoveState : PlayableCharacterBaseState
{
	const float PARMIT_STAMINA = 5F; 
	const float CONSUMPTION = 0.5F;
	
	private IGamePad gamepad;
	private CharacterAnimationController animation;
	private FrameCounter framecounter;
	public PlayableCharacterDashMoveState(PlayableCharacter parent, IGamePad pad):base(parent)
	{
		framecounter = new FrameCounter(4);
		gamepad = pad;
		animation = stateParent.animation as CharacterAnimationController;
	}
	
	public override IState Update()
	{
		IState newState = CheckOfKey();
		
		DashMove();
		
		StaminaUse();
		
		AnimationFrameUpdate();
		
		return newState;
	}
	
	private IState CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(st == Stick.None)return new PlayableCharacterStayState(character, gamepad);
			
		stateParent.baseParameter.moveParameter.direction = (int)st;
		animation.SetPatternByStick(st);
		
		if(!gamepad.IsPush(Button.D) || parameter.stamina.quantity < CONSUMPTION)
			return new PlayableCharacterMoveState(character, gamepad);
		
		return null;
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
	
	private void AnimationFrameUpdate()
	{
		framecounter.Update();
		if(framecounter.IsCall)animation.ChangeFrame(true);
	}
	
	static public bool IsParmittion(Stamina stamina)
	{
		return stamina.quantity > PARMIT_STAMINA;
	}
}

