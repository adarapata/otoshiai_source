using UnityEngine;
using System.Collections;

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