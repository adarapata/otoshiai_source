using UnityEngine;
using System.Collections;

public class CharacterFallState : CharacterBaseState
{
	private float scale = 0.95F;
	public CharacterFallState(Character parent):base(parent)
	{
		framecounter = new FrameCounter(60);
	}
	
	public override int Update()
	{
		var state = FrameUpdate();
		
		Falling();
		
		return (int)state;
	}
	
	private void Falling()
	{
		Vector3 fall = character.transform.localScale;
		fall.x *= scale;fall.y *= scale;
	  	character.transform.localScale = fall;
	}
	
	private Character.STATENAME FrameUpdate()
	{
		framecounter.Update();
        if (framecounter.IsCall) { SoundManager.Play(SoundManager.death); }
		return framecounter.IsCall ? Character.STATENAME.Dead : Character.STATENAME.Changeless;
	}
}

