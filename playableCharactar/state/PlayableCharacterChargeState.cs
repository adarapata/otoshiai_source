using UnityEngine;
using System.Collections;

public class PlayableCharacterChargeState : PlayableCharacterMoveState
{
	private const float MAX = 100F;
	private readonly string pushButton;
	
	private Charge charge
	{
		get;
		set;
	}
	
	public PlayableCharacterChargeState(PlayableCharacter parent, IGamePad pad, string push):base(parent,pad)
	{
		charge = parent.parameter.charge;
		pushButton = push;
		charge = new Charge();
	}
	
	protected override void Init()
	{
		framecounter = new FrameCounter(16);
		fix = new MoveFix(0.5F);
	}
	
	public override IState Update()
	{
		IState st = CheckOfKey();
		
		charge.Charging();
				
		return st;
	}
	
	protected override IState CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(gamepad.IsUp(pushButton))
		{
			return new PlayableCharacterStayState(character,gamepad);
		}
		
		if(st != Stick.None){
			SetDirectionByStick(st);
			Move();
			AnimationFrameUpdate();
		}
		
		return null;
	}
}

