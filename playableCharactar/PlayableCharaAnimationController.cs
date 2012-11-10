using UnityEngine;
using System.Collections;


public class CharactarAnimation
{
	public const string UP = "up";
}
	
public class PlayableCharaAnimationController : IAnimationController
{
	public UISprite sprite
	{
		get;
		set;
	}
	private int frame;
	private string pattern;
	
	public PlayableCharaAnimationController(UISprite targetSprite)
	{
		sprite = targetSprite;
	}
	
	public void ChangeFrame(bool isLoop)
	{
		sprite.spriteName = pattern + frame.ToString();
	}
	
	public bool ChangePattern(string newPattern)
	{
		Debug.Log(sprite);
		pattern = newPattern;
		sprite.spriteName = pattern + "0";
		return true;
	}
	
	
}

