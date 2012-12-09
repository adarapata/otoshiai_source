using UnityEngine;
using System.Collections;

public class PlayableCharacterBaseState : BaseState
{
	protected PlayableCharacter character
	{
		get;
		set;
	}
	new protected PlayableCharacter stateParent
	{
		get {return character;}
		set {character = value;}
	}
	protected CharacterParameter parameter
	{
		get { return character.parameter; }
		set { character.parameter = value; }
	}
	
	protected FrameCounter framecounter
	{
		get;
		set;
	}
	public PlayableCharacterBaseState(PlayableCharacter parent):base(parent)
	{
		character = parent;
	}
}

