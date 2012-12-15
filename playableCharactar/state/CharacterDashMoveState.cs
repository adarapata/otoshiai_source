using UnityEngine;
using System.Collections;

public class CharacterDashMoveState : CharacterMoveState
{
	private const float PARMIT_STAMINA = 5F; 
	private const float CONSUMPTION = 0.5F;
	
	public CharacterDashMoveState(Character parent, IGamePad pad):base(parent,pad)
	{

	}
	
	protected override void Init ()
	{
		framecounter = new FrameCounter(4);
		fix = new MoveFix(2F);
	}
	
	public override System.Type Update()
	{
		var newState = CheckOfKey();
		
		Move();
		
		StaminaUse();
		
		AnimationFrameUpdate();
		
		return newState;
	}
	
	protected override System.Type CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(st == Stick.None)return typeof(CharacterStayState);
			
		if(gamepad.IsPush(Button.A))return typeof(CharacterChargeState);
		if(gamepad.IsPush(Button.B))return typeof(CharacterChargeState);
		
		SetDirectionByStick(st);
		
		if(!gamepad.IsPush(Button.D) || parameter.stamina.quantity < CONSUMPTION)
			return typeof(CharacterMoveState);
		
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

