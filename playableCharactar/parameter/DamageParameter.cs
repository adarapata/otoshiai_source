using UnityEngine;
using System.Collections;

public class DamageParameter
{
    private MoveParameter moveParameter
    {
        get;
        set;
    }

    /// <summary>
    /// 防御力を無視するか
    /// </summary>
    private bool isIgnoreDeffence
    {
        get;
        set;
    }

    /// <summary>
    /// ダメージ量
    /// </summary>
    public float damage
    {
        get { return moveParameter.speed; }
        set { moveParameter.speed = value; }
    }

    /// <summary>
    /// ダメージの方向
    /// </summary>
    public int direction
    {
        get { return moveParameter.direction; }
        set { moveParameter.direction = value; }
    }

    public DamageParameter(int dir, float damage, bool ignoreDeffence)
    {
        moveParameter = new MoveParameter(dir, damage);
        isIgnoreDeffence = ignoreDeffence;
    }

    /// <summary>
    /// キャラのパラメータを元にダメージ計算
    /// </summary>
    /// <param name="character"></param>
    public void DamageCalculate(CharacterParameter character)
    {
        float deffence = isIgnoreDeffence ? 1F : character.diffence.quantity;

        damage = damage * deffence * (Weight.MIDDLE / character.weight.quantity);
    }

    public Vector3 velocity
    {
        get { return moveParameter.velocity; }
    }
}