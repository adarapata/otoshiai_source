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

