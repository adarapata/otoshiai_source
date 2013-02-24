using UnityEngine;
using System.Collections;

public class CharacterChargeSkillState : CharacterBaseState {

    public override int name
    {
        get { return (int)Character.STATENAME.ChargeSkill; }
    }
    public CharacterChargeSkillState(Character parent):base(parent)
	{

	}
	
	public override int Update()
	{
        return (int)Character.STATENAME.Stay;
	}
}
