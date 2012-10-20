using UnityEngine;
using System.Collections;

class MoveState : BaseState
{
	private MoveParameter moveParameter;
	
	public MoveState(BaseCharactar parent):base(parent)
	{
		moveParameter = stateParent.baseParameter.moveParameter;
	}
	
	public void Update()
	{
		stateParent.transform.localPosition += moveParameter.velocity;
	}
}

