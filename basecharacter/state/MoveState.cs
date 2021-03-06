using UnityEngine;
using System.Collections;

public class MoveState : BaseState
{
	protected MoveParameter moveParameter;

    public int name
    {
        get { return (int)GENERICSTATENAME.Move; }
    }

	
	public MoveState(BaseCharacter parent):base(parent)
	{
		moveParameter = stateParent.baseParameter.moveParameter;
	}
	
	public override int Update()
	{
		stateParent.transform.localPosition += moveParameter.velocity;
        return (int)GENERICSTATENAME.Changeless;
	}
}

