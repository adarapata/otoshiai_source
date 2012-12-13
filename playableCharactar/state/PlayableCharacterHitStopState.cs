using UnityEngine;
using System.Collections;

public class PlayableCharacterHitStopState : PlayableCharacterBaseState
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
	
	public PlayableCharacterHitStopState(PlayableCharacter parent,IGamePad pad, Damage damage):base(parent)
	{
		gamepad = pad;
		this.damage = damage;
	}
	
	public override IState Update()
	{
		hitstop.Update();
		if(hitstop.isEnd){return new PlayableCharacterDamageState(character, damage.damageParameter);}
		
		return null;
	}
}

