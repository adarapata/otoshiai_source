using UnityEngine;
using System.Collections;

public class PlayableCharaBaseState : BaseState
{
	protected PlayableCharacter character
	{
		get;
		set;
	}
	protected CharacterParameter parameter
	{
		get { return character.parameter; }
		set { character.parameter = value; }
	}
	public PlayableCharaBaseState(PlayableCharacter parent):base(parent)
	{
		character = parent;
	}
}

