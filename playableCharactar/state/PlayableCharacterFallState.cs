using UnityEngine;
using System.Collections;

public class PlayableCharacterFallState : PlayableCharacterBaseState
{
	private float scale = 0.95F;
	public PlayableCharacterFallState(PlayableCharacter parent):base(parent)
	{
		framecounter = new FrameCounter(60);
	}
	
	public override IState Update()
	{
		IState state = FrameUpdate();
		
		Falling();
		
		return state;
	}
	
	private void Falling()
	{
		Vector3 fall = character.transform.localScale;
		fall.x *= scale;fall.y *= scale;
	  	character.transform.localScale = fall;
	}
	
	private IState FrameUpdate()
	{
		framecounter.Update();
		
		return framecounter.IsCall ? new PlayableCharacterDeadState(character) : null;
	}
}

