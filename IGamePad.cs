using UnityEngine;
using System.Collections;

public enum Button
{
	A,
	B,
	C,
	D,
	Start
}

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

public interface IGamePad
{
	Stick pushStick {get;}
	Stick downStick {get;}
	Stick upStick {get;}

	bool IsPush(Button button);
	bool IsDown(Button button);
	bool IsUp(Button button);
	
	bool IsPushStick(Stick stick);
	bool IsDownStick(Stick stick);
	bool IsUpStick(Stick stick);
	
	void Update();
}

