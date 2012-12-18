using UnityEngine;
using System.Collections;

public class CharacterChargeBlowState : CharacterBaseState {

    public CharacterChargeBlowState(Character parent):base(parent)
	{

	}
	
	public override System.Type Update()
	{
        return typeof(CharacterStayState);
	}
}
