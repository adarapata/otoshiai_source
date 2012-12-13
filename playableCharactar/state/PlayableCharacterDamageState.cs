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
	
	public override IState Update()
	{
		IState state = BlowOffDamage();
		return state;
	}
	
	private IState BlowOffDamage()
	{
		character.transform.localPosition += parameter.velocity;
		if(parameter.damage < 0) { typeof(PlayableCharacterStayState).GetType();}
		
		return null;
	}
}

