using UnityEngine;
using System.Collections;

public class CharacterDashMoveState : CharacterMoveState
{
	private const float PARMIT_STAMINA = 5F; 
	private const float CONSUMPTION = 0.5F;

    public override int name
    {
        get { return (int)Character.STATENAME.DashMove; }
    }

	public CharacterDashMoveState(Character parent, IGamePad pad):base(parent,pad)
	{

	}
	
	protected override void Init ()
	{
		framecounter = new FrameCounter(4);
		fix = new MoveFix(2F);
	}
	
	public override int Update()
	{
		var newState = CheckOfKey();
		
		Move();
		
		StaminaUse();
		
		AnimationFrameUpdate();
		
		return (int)newState;
	}
	
	protected override Character.STATENAME CheckOfKey()
	{
		Stick st = gamepad.pushStick;

        if (st == Stick.None) return Character.STATENAME.Stay;
			
		if(gamepad.IsPush(Button.A) | gamepad.IsPush(Button.B))return Character.STATENAME.Charge;
		
		SetDirectionByStick(st);
		
		if(!gamepad.IsPush(Button.D) || parameter.stamina.quantity < CONSUMPTION)
			return Character.STATENAME.Move;
		
		return Character.STATENAME.Changeless;
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

