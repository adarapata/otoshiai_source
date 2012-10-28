using UnityEngine;
using System.Collections;

public interface IObjectOperator
{
	void Update();
	
	BaseCharactar OperationObject {get;set;}
}