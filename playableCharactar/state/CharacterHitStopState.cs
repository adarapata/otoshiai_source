using UnityEngine;
using System.Collections;

public class CharacterHitStopState : CharacterBaseState
{
	private IGamePad gamepad;
	private Damage damage
	{
		get;
		set;
	}
	private HitStop hitstop
	{
		get { return damage.hitStop; }
	}
	
	public CharacterHitStopState(Character parent,IGamePad pad, Damage damages):base(parent)
	{
		gamepad = pad;
        this.damage = damages;
	}
	
	public override System.Type Update()
	{
		hitstop.Update();
		if(hitstop.isEnd){ return typeof(CharacterDamageState);}

        CharacterShake();
		return null;
	}

    /// <summary>
    /// 左右に揺らしてダメージっぽいエフェクトをかける
    /// </summary>
    private void CharacterShake()
    {
        var pos = character.transform.localPosition;
        pos.x += hitstop.quantity % 2 == 0 ? 2 : -2;
        character.transform.localPosition = pos;
    }
}

