using UnityEngine;
using System.Collections;

public class CharacterDeadState : CharacterBaseState
{
    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="parent"></param>
	public CharacterDeadState(Character parent):base(parent)
	{

	}
	
	public override System.Type Update()
	{
		return null;
	}
}

