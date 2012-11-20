using UnityEngine;
using System.Collections;

public class PlayableCharaBaseState : BaseState
{
	protected PlayableCharacter character;
	protected CharacterParameter parameter;
	public PlayableCharaBaseState(PlayableCharacter parent):base(parent)
	{
		character = parent;
		parameter = parent.parameter;
	}
}

