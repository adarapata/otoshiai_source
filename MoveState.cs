using UnityEngine;
using System.Collections;

public class MoveState : BaseState
{
	protected MoveParameter moveParameter;
	
	public MoveState(BaseCharacter parent):base(parent)
	{
		moveParameter = stateParent.baseParameter.moveParameter;
	}
	
	public override System.Type Update()
	{
		stateParent.transform.localPosition += moveParameter.velocity;
		return null;
	}
}

