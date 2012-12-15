using UnityEngine;
using System.Collections;

public class CharacterHitStopState : CharacterBaseState
{
	private IGamePad gamepad;
	private Damage damage
	{
		get;
		set;
	}
	private HitStop hitstop
	{
		get { return damage.hitStop; }
	}
	
	public CharacterHitStopState(Character parent,IGamePad pad, Damage damage):base(parent)
	{
		gamepad = pad;
		this.damage = damage;
	}
	
	public override System.Type Update()
	{
		hitstop.Update();
		if(hitstop.isEnd){return typeof(CharacterDamageState);}
		
		return null;
	}
}

