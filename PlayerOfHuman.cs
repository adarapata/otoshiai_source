using UnityEngine;
using System.Collections;

public class PlayerOfHuman : IObjectOperator
{
	public IGamePad gamePad
	{
		get;
		set;
	}
	
	public BaseCharactar OperationObject
	{
		get;
		set;
	}
	
	public void Update()
	{
		
	}
}

