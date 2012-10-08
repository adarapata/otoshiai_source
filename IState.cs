using UnityEngine;
using System.Collections;

public interface IState {

	void Update();
}

public class StateManager {
	IState state;
	
	public void SetFirstState(IState firstState)
	{
		if(state == null)state = firstState;
	}
	
	public void Update()
	{
		state.Update();
	}
	
	public void ChangeState(IState nextState)
	{
		state = nextState;
	}
}

public class BaseState :IState {
	protected BaseCharactar stateParent;
	protected StateManager stateManager;
	
	public BaseState(StateManager manager, BaseCharactar baseCharactar)
	{
		stateManager = manager;
		stateParent = baseCharactar;
	}
	
	public void Update()
	{
		
	}
}
