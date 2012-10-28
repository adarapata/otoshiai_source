using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム中のオブジェクトを操作するインタフェース
/// </summary>
public interface IObjectOperator
{
	void Update();
	
	BaseCharactar OperationObject {get;set;}
}