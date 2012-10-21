using UnityEngine;
using System.Collections;

public class GamePad : IGamePad
{
	private Stick stickPush;
	private Stick stickUp;
	private Stick stickDown;
	private Vector2 stickData;
	
	public Stick pushStick{ get{ return stickPush;} }
	public Stick downStick{ get{ return stickDown;} }
	public Stick upStick{ get{ return stickUp;} }
	
	private Stick getPushStick{
		get 
		{
			if(match( 1, 0))return Stick.Right;
			if(match(-1, 0))return Stick.Left;
			if(match( 0, 1))return Stick.Up;
			if(match( 0,-1))return Stick.Down;

			if(match(-1, 1))return Stick.LeftUp;
			if(match( 1,-1))return Stick.RightDown;
			if(match( 1, 1))return Stick.RightUp;
			if(match(-1,-1))return Stick.LeftDOwn;

			return Stick.None;
		}
	}
	
	public bool IsPush(Button button)
	{
		return Input.GetButton(button.ToString());
	}
	
	public bool IsDown(Button button)
	{
		return Input.GetButtonDown(button.ToString());
	}
	
	public bool IsUp(Button button)
	{
		return Input.GetButtonUp(button.ToString());
	}
	
	public bool IsPushStick(Stick stick)
	{
		return stick == stickPush;
	}
	
	public bool IsDownStick(Stick stick)
	{
		return stick == stickDown;
	}
	
	public bool IsUpStick(Stick stick)
	{
		return stick == stickUp;
	}
	
	public void Update()
	{
		stickData = new Vector2(Input.GetAxisRaw("Horizontal"),
							Input.GetAxisRaw("Vertical"));
		
		Stick before = stickPush;
		
		stickPush = getPushStick;
		stickDown = stickDown != stickPush ? stickPush : Stick.None;
		stickUp = stickPush == Stick.None ? before : Stick.None;
	}
	
	private bool match(float x,float y)
	{
		return stickData.x == x && stickData.y == y;
	}
	
	
}

