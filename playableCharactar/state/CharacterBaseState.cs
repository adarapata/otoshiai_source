using UnityEngine;
using System.Collections;

public class CharacterBaseState : BaseState
{
	protected Character character
	{
		get;
		set;
	}
	new protected Character stateParent
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
	public CharacterBaseState(Character parent):base(parent)
	{
		character = parent;
	}
}

