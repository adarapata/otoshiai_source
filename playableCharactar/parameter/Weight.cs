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
}

