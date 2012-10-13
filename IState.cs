using UnityEngine;
using System.Collections;

public interface IState {
	
	void Update();
}


public class BaseState :IState {
	protected BaseCharactar stateParent;
	
	public BaseState(BaseCharactar baseCharactar)
	{
		stateParent = baseCharactar;
	}
	
	public void Update()
	{
		
	}
}
