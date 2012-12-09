using UnityEngine;
using System.Collections;

public class PlayableCharacterDeadState : PlayableCharacterBaseState
{
	public PlayableCharacterDeadState(PlayableCharacter parent):base(parent)
	{

	}
	
	public override IState Update()
	{
		return null;
	}
}

