using UnityEngine;
using System.Collections;

public class PlayableCharacterChargeState : PlayableCharacterBaseState
{
	private const float MAX = 100F;
	private IGamePad gamepad;
	
	private Charge charge
	{
		get;
		set;
	}
	public PlayableCharacterChargeState(PlayableCharacter parent, IGamePad pad):base(parent)
	{
		charge = parent.parameter.charge;
		gamepad = pad;
	}
	
	public override IState Update()
	{
		charge.Charging();
		
		return null;
	}
	
	private void CheckKey()
	{
		Stick st = gamepad.pushStick;
		
		
		if(st == Stick.None){}
	}
}

