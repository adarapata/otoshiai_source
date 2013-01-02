using UnityEngine;
using System.Collections;

public interface IAnimationController
{
	UISprite sprite {get;set;}
    AnimationParameter parameter { get; set; }
	void ChangeFrame(bool isLoop);
	bool ChangePattern(string patternName);	
}

