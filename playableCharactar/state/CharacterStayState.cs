using UnityEngine;
using System.Collections;

public class CharacterStayState : CharacterBaseState {
	
	private IGamePad gamepad;
	
	public CharacterStayState(Character parent,IGamePad pad):base(parent)
	{
		gamepad = pad;
	}
	
	public override int Update()
	{
		StaminaRecover();
		return (int)CheckKeyState();
	}
	
	private Character.STATENAME CheckKeyState()
	{
		var stick = gamepad.pushStick;

        if (gamepad.GetChargeButton != null) return Character.STATENAME.Charge;

        if(stick == Stick.None) return Character.STATENAME.Changeless;
		
		return GetStateWhenPushStick();
	}
	
	private Character.STATENAME GetStateWhenPushStick()
	{
        if (gamepad.IsPush(Button.D) && CharacterDashMoveState.IsParmittion(parameter.stamina)) return Character.STATENAME.DashMove;
        return Character.STATENAME.Move;
	}
	
	private void StaminaRecover()
	{
		parameter.stamina.Recovery();
	}
}
