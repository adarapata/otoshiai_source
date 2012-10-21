using UnityEngine;
using System.Collections;

public class MoveState : BaseState
{
	protected MoveParameter moveParameter;
	
	public MoveState(BaseCharactar parent):base(parent)
	{
		moveParameter = stateParent.baseParameter.moveParameter;
	}
	
	virtual public void Update()
	{
		stateParent.transform.localPosition += moveParameter.velocity;
	}
}

