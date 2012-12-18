using UnityEngine;
using System.Collections;

public class CharacterChargeSkillState : CharacterBaseState {

    public CharacterChargeSkillState(Character parent):base(parent)
	{

	}
	
	public override System.Type Update()
	{
        return typeof(CharacterStayState);
	}
}
