using UnityEngine;
using System.Collections;

public class Damage
{
    /// <summary>
    /// ダメージの重ねがけができるか
    /// </summary>
    private bool isAddDamage
    {
        get;
        set;
    }

    /// <summary>
    /// 停止時間
    /// </summary>
    public HitStop hitStop
    {
        get;
        set;
    }

    /// <summary>
    /// ダメージのパラメータ
    /// </summary>
    public DamageParameter damageParameter
    {
        get;
        set;
    }

    public Damage(int hitstop, bool addDamage, float damage, int direction, bool ignoreDeffence)
    {
        hitStop = new HitStop(hitstop);
        isAddDamage = addDamage;
        damageParameter = new DamageParameter(direction, damage, ignoreDeffence);
    }

    /// <summary>
    /// ダメージの値を重ねがけする
    /// </summary>
    /// <param name="oldParameter"></param>
    public Damage AddDamage(Damage oldDamage)
    {
        if (isAddDamage)
        {
            damageParameter.damage += oldDamage.damageParameter.damage;
            return this;
        }
        return oldDamage;
    }
}
