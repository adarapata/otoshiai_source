using UnityEngine;
using System.Collections;

public class IkariMoveState : BaseState{
    protected MoveParameter moveParameter;

    private float accel;
    private Ikari ikari;
	public IkariMoveState(Ikari parent):base(parent)
	{
        ikari = parent;
		moveParameter = stateParent.baseParameter.moveParameter;
        accel = 0;
	}
	
	public override System.Type Update()
	{
		stateParent.transform.localPosition += moveParameter.velocity;
        moveParameter.speed = accel;
        accel += 0.1F;

        if (ikari.IsOutMap) { ikari.ChangeNextState(typeof(IkariReturnState)); }

		return null;
	}
}
