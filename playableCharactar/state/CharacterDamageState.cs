using UnityEngine;
using System.Collections;

public class CharacterDamageState : CharacterBaseState
{
	private DamageParameter damageParameter
	{
		get;
		set;
	}
	public CharacterDamageState(Character parent,DamageParameter dParameter):base(parent)
	{
		damageParameter = dParameter;
		damageParameter.DamageCalculate(character.parameter);
	}
	
	public override System.Type Update()
	{
		var state = BlowOffDamage();
		return state;
	}
	
    /// <summary>
    /// 吹っ飛び処理
    /// </summary>
    /// <returns></returns>
	private System.Type BlowOffDamage()
	{
		character.transform.localPosition += damageParameter.velocity;
        damageParameter.damage--;
		if(damageParameter.damage < 0) 
        {
            CreateBlinkAndInvincibly(60);
            character.parameter.damage = null;
            return typeof(CharacterStayState); 
        }
		
		return null;
	}

    /// <summary>
    /// ダメージ終了後の無敵状態＆点滅の設定
    /// </summary>
    /// <param name="time"></param>
    private void CreateBlinkAndInvincibly(int time)
    {
        character.baseParameter.blinkParameter.Start(time, false);        parameter.invincibly.Start(time, false);
        
    }
}

