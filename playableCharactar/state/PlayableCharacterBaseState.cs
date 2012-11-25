using UnityEngine;
using System.Collections;

public class PlayableCharacterBaseState : BaseState
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
	public PlayableCharacterBaseState(PlayableCharacter parent):base(parent)
	{
		character = parent;
	}
}

