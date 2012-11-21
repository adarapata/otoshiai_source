using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterAnimationController : IAnimationController
{
	class Animations
	{
		public const string UP = "up",
						DOWN = "down",
						RIGHT = "right",
						LEFT = "left",
						UPRIGHT = "upright",
						UPLEFT = "upleft",
						DOWNRIGHT = "downright",
						DOWNLEFT = "downleft";
	}
	
	public UISprite sprite
	{
		get;
		set;
	}
	
	private AnimationParameter parameter;
	
	public CharacterAnimationController(UISprite targetSprite)
	{	
		sprite = targetSprite;
		var list = targetSprite.atlas.GetListOfSprites();
		parameter = new AnimationParameter(list);
	}
	
	public void ChangeFrame(bool isLoop)
	{
		sprite.spriteName = parameter.NextFrame(true);
	}
	
	public bool ChangePattern(string newPattern)
	{
		string pattern = parameter.ChangePattern(newPattern);
		if(pattern == "")return false;
		
		sprite.spriteName = pattern;
		return true;
	}
	
	public void SetPatternByStick(Stick st)
	{
		if(st == Stick.None)return;
		
		string newPattern="";
		switch(st)
		{
			case Stick.Down:newPattern = Animations.DOWN;break;
			case Stick.Up:newPattern = Animations.UP;break;
			case Stick.Right:newPattern = Animations.RIGHT;break;
			case Stick.Left:newPattern = Animations.LEFT;break;
			case Stick.RightDown:newPattern = Animations.DOWNRIGHT;break;
			case Stick.RightUp:newPattern = Animations.UPRIGHT;break;
			case Stick.LeftUp:newPattern = Animations.UPLEFT;break;
			case Stick.LeftDOwn:newPattern = Animations.DOWNLEFT;break;
		}
		
		if(parameter.pattern == newPattern)return;
		ChangePattern(newPattern);
	}
}

public class AnimationParameter
{
	public int frame;
	public string pattern;
	private List<string> nameList;
	
	public AnimationParameter(List<string> animationNameList)
	{
		nameList = animationNameList;
	}
	
	public string NextFrame(bool isLoop)
	{
		frame = nameList.Contains(pattern + (frame+1).ToString()) ? frame + 1 : 0;
		string nextframe = pattern + frame.ToString();
		return nextframe;
	}
	
	public string ChangePattern(string newPattern)
	{
		if(!nameList.Contains(newPattern + "0"))return "";
		
		pattern = newPattern + "0";
		return pattern;
	}
}