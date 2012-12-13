using UnityEngine;
using System.Collections;

public class PlayableCharacterStayState : PlayableCharacterBaseState {
	
	private IGamePad gamepad;
	
	public PlayableCharacterStayState(PlayableCharacter parent,IGamePad pad):base(parent)
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
		if(stick == Stick.None) return null;
		
		return GetStateWhenPushStick();
	}
	
	private System.Type GetStateWhenPushStick()
	{
		if(gamepad.IsPush(Button.A))return typeof(PlayableCharacterChargeState);
		if(gamepad.IsPush(Button.B))return typeof(PlayableCharacterChargeState);
		
		if(gamepad.IsPush(Button.D) && PlayableCharacterDashMoveState.IsParmittion(parameter.stamina))return typeof(PlayableCharacterDashMoveState);
		return typeof(PlayableCharacterMoveState);
	}
	
	private void StaminaRecover()
	{
		parameter.stamina.Recovery();
	}
}
