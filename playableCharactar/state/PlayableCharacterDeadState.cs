using UnityEngine;
using System.Collections;

public class PlayableCharacterDeadState : PlayableCharacterBaseState
{
    /// <summary>
    /// �R���X�g���N�^
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

