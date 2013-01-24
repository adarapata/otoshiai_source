using UnityEngine;
using System.Collections;

public class Weight
{
    public const float HEAVY = 65F;
    public const float MIDDLE = 50F;
    public const float LIGHT = 35F;

    public float quantity
    {
        get;
        set;
    }

    static public Vector3 CalculateVelocityByWeight(MoveParameter param, Weight weight)
    {
        return param.velocity * (Weight.MIDDLE / weight.quantity);
    }

    /// <summary>
    /// 自身の体重を元にマップチップに与えるダメージを計算する
    /// </summary>
    /// <returns></returns>
    public float DamageToMapChip()
    {
        //乗っている人の体重が並以下なら変化なし
        if (quantity <= MIDDLE) { return 0; }

        return quantity / MIDDLE;
    }
}

