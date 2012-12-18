using UnityEngine;
using System.Collections;

public class CharacterBlowState : CharacterBaseState {
	
	public CharacterBlowState(Character parent):base(parent)
	{

	}
	
	public override System.Type Update()
	{
        return typeof(CharacterStayState);
	}
}
