using UnityEngine;
using System.Collections;

public class MoveState : BaseState
{
	protected MoveParameter moveParameter;
	
	public MoveState(BaseCharacter parent):base(parent)
	{
		moveParameter = stateParent.baseParameter.moveParameter;
	}
	
	public override IState Update()
	{
		stateParent.transform.localPosition += moveParameter.velocity;
		return null;
	}
}

