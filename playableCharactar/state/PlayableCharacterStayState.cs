using UnityEngine;
using System.Collections;

public class PlayableCharacterStayState : PlayableCharacterBaseState {
	
	private IGamePad gamepad;
	
	public PlayableCharacterStayState(PlayableCharacter parent,IGamePad pad):base(parent)
	{
		gamepad = pad;
	}
	
	public override IState Update()
	{
		StaminaRecover();
		return CheckKeyState();
	}
	
	private IState CheckKeyState()
	{
		var stick = gamepad.pushStick;
		if(stick == Stick.None) return null;
		
		return GetStateWhenPushStick();
	}
	
	private IState GetStateWhenPushStick()
	{
		if(gamepad.IsPush(Button.D) && PlayableCharacterDashMoveState.IsParmittion(parameter.stamina))return new PlayableCharacterDashMoveState(character, gamepad);	
		return new PlayableCharacterMoveState(character, gamepad);	
	}
	
	private void StaminaRecover()
	{
		parameter.stamina.Recovery();
	}
}
