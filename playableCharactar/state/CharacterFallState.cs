using UnityEngine;
using System.Collections;

public class CharacterFallState : CharacterBaseState
{
	private float scale = 0.95F;
	public CharacterFallState(Character parent):base(parent)
	{
		framecounter = new FrameCounter(60);
	}
	
	public override System.Type Update()
	{
		var state = FrameUpdate();
		
		Falling();
		
		return state;
	}
	
	private void Falling()
	{
		Vector3 fall = character.transform.localScale;
		fall.x *= scale;fall.y *= scale;
	  	character.transform.localScale = fall;
	}
	
	private System.Type FrameUpdate()
	{
		framecounter.Update();
		
		return framecounter.IsCall ? typeof(CharacterDeadState) : null;
	}
}

