using UnityEngine;
using System.Collections;

public class CharacterSkillState : CharacterBaseState {

    public CharacterSkillState(Character parent):base(parent)
	{

	}
	
	public override int Update()
	{
        return (int)Character.STATENAME.Stay;
	}
}
