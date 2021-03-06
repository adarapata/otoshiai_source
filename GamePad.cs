using UnityEngine;
using System.Collections;

public class GamePad : IGamePad
{
    private readonly string playerNumber;
	private Stick stickPush;
	private Stick stickUp;
	private Stick stickDown;
	private Vector2 stickData;
    //private const string[] playerNumbers = new [] { "P1-", "P2-", "P3-", "P4-" };
	
	public Stick pushStick{ get{ return stickPush;} }
	public Stick downStick{ get{ return stickDown;} }
	public Stick upStick{ get{ return stickUp;} }

    private string GetAxesFullName(string name)
    {
        return playerNumber + name;
    }

	private Stick getPushStick{
		get 
		{
			if(match( 1, 0))return Stick.Right;
			if(match(-1, 0))return Stick.Left;
			if(match( 0,-1))return Stick.Up;
			if(match( 0, 1))return Stick.Down;

			if(match(-1,-1))return Stick.LeftUp;
			if(match( 1, 1))return Stick.RightDown;
			if(match( 1,-1))return Stick.RightUp;
			if(match(-1, 1))return Stick.LeftDOwn;

			return Stick.None;
		}
	}

    public GamePad(int number)
    {
        playerNumber = "P" + (number + 1).ToString() + "-";
    }

	public bool IsPush(string button)
	{
		return Input.GetButton(GetAxesFullName(button));
	}
	
	public bool IsDown(string button)
	{
		return Input.GetButtonDown(GetAxesFullName(button));
	}
	
	public bool IsUp(string button)
	{
		return Input.GetButtonUp(GetAxesFullName(button));
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
		stickData = new Vector2(Input.GetAxisRaw(GetAxesFullName("StickX")),
							Input.GetAxisRaw(GetAxesFullName("StickY")));

		Stick before = stickPush;
		
		stickPush = getPushStick;
		stickDown = before != stickPush ? stickPush : Stick.None;
		stickUp = stickPush == Stick.None ? before : Stick.None;
	}
	
	private bool match(int x,int y)
	{
		return (int)stickData.x == x && (int)stickData.y == y;
	}

    public string GetChargeButton
    {
        get 
        {
            if (IsPush(Button.A)) return Button.A;
            if (IsPush(Button.B)) return Button.B;
            return null;
        }
    }
}

