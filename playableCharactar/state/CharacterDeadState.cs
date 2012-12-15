using UnityEngine;
using System.Collections;

public class CharacterDeadState : CharacterBaseState
{
    /// <summary>
    /// コンストラクタ
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

