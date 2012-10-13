using UnityEngine;
using System.Collections;

public class BaseCharactar : MonoBehaviour {
	public IState state {
		get;
		set;
	}
	
	public BaseParameter baseParameter {
		get;
		set;
	}
	
	// Use this for initialization
	void Start () {
		state = new BaseState(this);
	}
	
	// Update is called once per frame
	void Update () {
		state.Update();
	}
}

public class MoveParameter {
	private Vector3 velocity;
	private float speed;
}

public class BlinkParameter {
	private int blinkTime;
}

public class BaseParameter {	
	public BlinkParameter blinkParameter {
		get;
		set;
	}
	
	public MoveParameter moveParameter {
		get;
		set;
	}
}