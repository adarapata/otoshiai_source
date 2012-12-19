using UnityEngine;
using System.Collections;

public class Damage
{
    /// <summary>
    /// �_���[�W�̏d�˂������ł��邩
    /// </summary>
    private bool isAddDamage
    {
        get;
        set;
    }

    /// <summary>
    /// ��~����
    /// </summary>
    public HitStop hitStop
    {
        get;
        set;
    }

    /// <summary>
    /// �_���[�W�̃p�����[�^
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
    /// �_���[�W�̒l���d�˂�������
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
