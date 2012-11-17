using UnityEngine;
using System.Collections;

/// <summary>
/// 人間がオブジェクトを操作する際に使うクラス
/// </summary>
public class PlayerOfHuman : IObjectOperator
{
	/// <summary>
	/// ゲームパッド情報
	/// get; set;
	/// </summary>
	/// <value>
	/// The game pad.
	/// </value>
	public IGamePad gamepad
	{
		get;
		set;
	}
	
	/// <summary>
	/// 操作対象のオブジェクト
	/// </summary>
	/// <value>
	/// The operation object.
	/// </value>
	public BaseCharacter operationObject
	{
		get;
		set;
	}
	
	public PlayerOfHuman()
	{
		gamepad = new GamePad();
	}
	public void Update()
	{
		
	}
}

