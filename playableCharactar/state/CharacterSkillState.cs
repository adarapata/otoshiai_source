using UnityEngine;
using System.Collections;

public class CharacterSkillState : CharacterBaseState {
    
    public CharacterSkillState(Character parent):base(parent)
	{

	}
	
	public override System.Type Update()
	{
        return typeof(CharacterStayState);
	}
}
