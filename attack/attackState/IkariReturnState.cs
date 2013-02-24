using UnityEngine;
using System.Collections;

public class IkariReturnState : BaseState {

    protected MoveParameter moveParameter;

    private float accel;
    private Ikari ikari;
    private Murasa returntarget;

    public int name
    {
        get { return (int)Ikari.STATENAME.Rerutn; }
    }

	public IkariReturnState(Ikari parent,Murasa target):base(parent)
	{
        ikari = parent;
		moveParameter = stateParent.baseParameter.moveParameter;
        moveParameter.direction += 180;
        accel = 0;
        returntarget = target;
	}
	
	public int Update()
	{
        Homing();

        if (Mathf.Abs(
            Vector2.Distance(returntarget.transform.localPosition, stateParent.transform.localPosition)) <= 24)
        {
            GameObject.Destroy(stateParent.gameObject);
        }

        return (int)Ikari.STATENAME.Changeless;
	}

    private void Homing()
    {
        int dir = GetHoming();
        moveParameter.direction += dir;

        stateParent.transform.localPosition += moveParameter.velocity;
        moveParameter.speed = accel;
        accel += 0.05F;

        stateParent.transform.eulerAngles = new Vector3(0, 0, moveParameter.direction+180);
    }

    private int GetHoming()
    {
        Vector2 pos = returntarget.transform.localPosition - stateParent.transform.localPosition;
        PolarCoordinates pol = new PolarCoordinates { direction = stateParent.baseParameter.moveParameter.direction, speed = 1 };
        Vector2 normal = pol.ConvertToPolar();
        float cross = normal.Ccw(pos);
        return cross > 0 ? 5 : -5;
    }
}
