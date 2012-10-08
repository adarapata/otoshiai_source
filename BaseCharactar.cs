using UnityEngine;
using System.Collections;

public class BaseCharactar : MonoBehaviour {
	
	public IState State {
		get;
		set;
	}
	
	// Use this for initialization
	void Start () {
		State = new BaseState(this);
	}
	
	// Update is called once per frame
	void Update () {
		State.Update();
	}
}