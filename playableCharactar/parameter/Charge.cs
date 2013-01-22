using UnityEngine;
using System.Collections;

public class Charge
{
    private const float MAX = 100F;

    public float quantity { private set; get; }
    public float speed { private set; get; }
    public bool isMax { get { return quantity >= MAX; } }
    /// <summary>
    /// チャージ中かどうかを返す。MAXの場合もtrueを返す
    /// </summary>
    public bool isCharging { get { return quantity > 0; } }
    public Charge(float chargeSpeed)
    {
        speed = chargeSpeed;
    }

    public void Charging()
    {
        quantity += speed;
        if (quantity > MAX) quantity = MAX;
    }

    public void Clear()
    {
        quantity = 0;
    }
}