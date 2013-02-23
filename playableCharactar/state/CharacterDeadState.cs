using UnityEngine;
using System.Collections;

public class CharacterDeadState : CharacterBaseState
{
    public int name
    {
        get { return (int)Character.STATENAME.Dead; }
    }
    /// <summary>
    /// コンストラクタ
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

