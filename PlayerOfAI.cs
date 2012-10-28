using UnityEngine;
using System.Collections;

/// <summary>
/// キャラクターを操作するAI
/// </summary>
public class PlayerOfAI : IObjectOperator
{
	/// <summary>
	/// 捜査対象のオブジェクト　　get; set;
	/// </summary>
	/// <value>
	/// The operation object.
	/// </value>
	public BaseCharactar operationObject
	{
		get;
		set;
	}
	
	public IGamePad gamepad
	{
		get;
		set;
	}
	
	public void Update()
	{
	
	}
}

