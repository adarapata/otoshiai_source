using UnityEngine;
using System.Collections;

public class PlayableCharacterDeadState : PlayableCharacterBaseState
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="parent"></param>
	public PlayableCharacterDeadState(PlayableCharacter parent):base(parent)
	{

	}
	
	public override System.Type Update()
	{
		return null;
	}
}

