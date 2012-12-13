using UnityEngine;
using System.Collections;

public class PlayableCharacterDamageState : PlayableCharacterBaseState
{
	private DamageParameter parameter
	{
		get;
		set;
	}
	public PlayableCharacterDamageState(PlayableCharacter parent,DamageParameter parameter):base(parent)
	{
		this.parameter = parameter;
		parameter.DamageCalculate(character.parameter);
	}
	
	public override System.Type Update()
	{
		var state = BlowOffDamage();
		return state;
	}
	
	private System.Type BlowOffDamage()
	{
		character.transform.localPosition += parameter.velocity;
		if(parameter.damage < 0) { return typeof(PlayableCharacterStayState); }
		
		return null;
	}
}

