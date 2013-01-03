using UnityEngine;
using System.Collections;

public class CharacterDamageState : CharacterBaseState
{
	private DamageParameter damageParameter
	{
		get;
		set;
	}
	public CharacterDamageState(Character parent,DamageParameter dParameter):base(parent)
	{
		damageParameter = dParameter;
		damageParameter.DamageCalculate(character.parameter);
	}
	
	public override System.Type Update()
	{
		var state = BlowOffDamage();
		return state;
	}
	
    /// <summary>
    /// ‚Á”ò‚Ñˆ—
    /// </summary>
    /// <returns></returns>
	private System.Type BlowOffDamage()
	{
		character.transform.localPosition += damageParameter.velocity;
        damageParameter.damage--;
		if(damageParameter.damage < 0) 
        {
            character.parameter.damage = null;
            return typeof(CharacterStayState); 
        }
		
		return null;
	}
}

