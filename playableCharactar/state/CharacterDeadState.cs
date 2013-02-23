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
	
	public override int Update()
	{
        return (int)Character.STATENAME.Changeless;
	}
}

