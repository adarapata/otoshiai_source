using UnityEngine;
using System.Collections;

public class PlayableCharacterDashMoveState : PlayableCharacterMoveState
{
	private const float PARMIT_STAMINA = 5F; 
	private const float CONSUMPTION = 0.5F;
	
	public PlayableCharacterDashMoveState(PlayableCharacter parent, IGamePad pad):base(parent,pad)
	{

	}
	
	protected override void Init ()
	{
		framecounter = new FrameCounter(4);
		fix = new MoveFix(2F);
	}
	
	public override IState Update()
	{
		IState newState = CheckOfKey();
		
		Move();
		
		StaminaUse();
		
		AnimationFrameUpdate();
		
		return newState;
	}
	
	protected override IState CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(st == Stick.None)return new PlayableCharacterStayState(character, gamepad);
			
		if(gamepad.IsPush(Button.A))return new PlayableCharacterChargeState(character, gamepad, Button.A);
		if(gamepad.IsPush(Button.B))return new PlayableCharacterChargeState(character, gamepad, Button.B);
		
		SetDirectionByStick(st);
		
		if(!gamepad.IsPush(Button.D) || parameter.stamina.quantity < CONSUMPTION)
			return new PlayableCharacterMoveState(character, gamepad);
		
		return null;
	}
	
	private void StaminaUse()
	{
		parameter.stamina.quantity -= CONSUMPTION;
	}
	
	static public bool IsParmittion(Stamina stamina)
	{
		return stamina.quantity > PARMIT_STAMINA;
	}
}

