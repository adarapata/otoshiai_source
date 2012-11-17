using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム中のオブジェクトを操作するインタフェース
/// </summary>
public interface IObjectOperator
{
	IGamePad gamepad { get; set;}
	BaseCharacter operationObject {get;set;}	
	void Update();
}