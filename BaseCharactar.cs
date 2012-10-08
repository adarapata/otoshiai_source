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
		stateManager.Update();
	}
	
	/// <summary>
	/// Defines the state.
	/// </summary>
	virtual protected void DefineState()
	{
		stateManager = new StateManager();
		IState state = new BaseState(stateManager, this);
		
		stateManager.SetFirstState(state);
	}
}