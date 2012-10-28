using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム中でのボタン名
/// </summary>
public enum Button
{
	A,
	B,
	C,
	D,
	Start
}

/// <summary>
/// スティックの方向
/// </summary>
public enum Stick
{
	None,
	Left,
	Right,
	Up,
	Down,
	LeftUp,
	LeftDOwn,
	RightUp,
	RightDown
}

/// <summary>
/// ゲームパッドのインタフェース
/// </summary>
public interface IGamePad
{
	/// <summary>
	/// 押されている方向を返す  
	/// get;
	/// </summary>
	/// <value>
	/// The push stick.
	/// </value>
	Stick pushStick {get;}
	/// <summary>
	/// 押した瞬間の方向を返す、
	/// 押した瞬間でなければStick.Noneを返す
	/// get;
	/// </summary>
	/// <value>
	/// Down stick.
	/// </value>
	Stick downStick {get;}
	/// <summary>
	/// 放した瞬間の方向を返す、
	/// 放した瞬間でなければStick.Noneを返す
	/// get;
	/// </summary>
	/// <value>
	/// Down stick.
	/// </value>
	Stick upStick {get;}
	
	/// <summary>
	/// ボタンが押されているかを返す
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is push the specified button; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='button'>
	/// If set to <c>true</c> button.
	/// </param>
	bool IsPush(Button button);
	/// <summary>
	/// ボタンが押した瞬間かどうかを返す
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is down the specified button; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='button'>
	/// If set to <c>true</c> button.
	/// </param>
	bool IsDown(Button button);
	/// <summary>
	/// ボタンが放した瞬間かどうかをかえす
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is up the specified button; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='button'>
	/// If set to <c>true</c> button.
	/// </param>
	bool IsUp(Button button);
	
	/// <summary>
	/// 十字キーが押されているかを返す
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is push stick the specified stick; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='stick'>
	/// If set to <c>true</c> stick.
	/// </param>
	bool IsPushStick(Stick stick);
	/// <summary>
	/// 十字キーが押された瞬間かを返す
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is down stick the specified stick; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='stick'>
	/// If set to <c>true</c> stick.
	/// </param>
	bool IsDownStick(Stick stick);
	/// <summary>
	/// 十字キーが放された瞬間かを返す
	/// </summary>
	/// <returns>
	/// <c>true</c> if this instance is up stick the specified stick; otherwise, <c>false</c>.
	/// </returns>
	/// <param name='stick'>
	/// If set to <c>true</c> stick.
	/// </param>
	bool IsUpStick(Stick stick);
	
	void Update();
}

