using UnityEngine;
using System.Collections;

public class BaseCharactar : MonoBehaviour {
	
	protected StateManager stateManager;
	// Use this for initialization
	void Start () {
		DefineState();
	}
	
	// Update is called once per frame
	void Update () {
		state.Update();
	}
	
	protected void ChangeState(IState nextState)
	{
		state = nextState;
	}
	/// <summary>
	/// Defines the state.
	/// </summary>
	virtual protected void DefineState()
	{
		IState state = new BaseState(this);
	}
}