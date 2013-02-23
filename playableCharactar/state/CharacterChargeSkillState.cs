using UnityEngine;
using System.Collections;

public class CharacterChargeSkillState : CharacterBaseState {

    public CharacterChargeSkillState(Character parent):base(parent)
	{

	}
	
	public override int Update()
	{
        return (int)Character.STATENAME.Stay;
	}
}
