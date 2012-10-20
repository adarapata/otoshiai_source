using UnityEngine;
using System.Collections;

public class PlayableCharactar : BaseCharactar {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

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