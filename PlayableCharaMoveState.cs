using UnityEngine;
using System.Collections;

/// <summary>
/// プレイアブルキャラクターの移動状態クラス
/// </summary>
public class PlayableCharaMoveState : MoveState
{
	public PlayableCharaMoveState(BaseCharactar parent):base(parent)
	{
        
	}
	
	public override void Update ()
	{
		base.Update();
	}
	
	private void CheckOfKey()
	{
		
	}
}

