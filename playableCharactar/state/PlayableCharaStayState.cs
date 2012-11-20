using UnityEngine;
using System.Collections;

public class PlayableCharaStayState : PlayableCharaBaseState {
	
	private IGamePad gamepad;
	
	public PlayableCharaStayState(PlayableCharacter parent,IGamePad pad):base(parent)
	{
		gamepad = pad;
	}
	
	public override void Update()
	{
		IState st = CheckKeyState();
		if(st != null) stateParent.state = st;
	}
	
	private IState CheckKeyState()
	{
		var stick = gamepad.pushStick;
		if(stick == Stick.None) return null;
		
		return new PlayableCharaMoveState(character, gamepad);	
	}
}
