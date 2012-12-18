using UnityEngine;
using System.Collections;

public class CharacterStayState : CharacterBaseState {
	
	private IGamePad gamepad;
	
	public CharacterStayState(Character parent,IGamePad pad):base(parent)
	{
		gamepad = pad;
	}
	
	public override System.Type Update()
	{
		StaminaRecover();
		return CheckKeyState();
	}
	
	private System.Type CheckKeyState()
	{
		var stick = gamepad.pushStick;

        if (gamepad.GetChargeButton != null) return typeof(CharacterChargeState);

        if(stick == Stick.None) return null;
		
		return GetStateWhenPushStick();
	}
	
	private System.Type GetStateWhenPushStick()
	{		
		if(gamepad.IsPush(Button.D) && CharacterDashMoveState.IsParmittion(parameter.stamina))return typeof(CharacterDashMoveState);
		return typeof(CharacterMoveState);
	}
	
	private void StaminaRecover()
	{
		parameter.stamina.Recovery();
	}
}
