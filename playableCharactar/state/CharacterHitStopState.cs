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
	
	public CharacterHitStopState(Character parent,IGamePad pad, Damage damages):base(parent)
	{
        Debug.Log(damages);
		gamepad = pad;
        this.damage = damages;
	}
	
	public override System.Type Update()
	{
        Debug.Log(damage);
		hitstop.Update();
		if(hitstop.isEnd){return typeof(CharacterDamageState);}
		
		return null;
	}
}

