using UnityEngine;
using System.Collections;

public class Charge
{
    private const float MAX = 100F;

    public float quantity { private set; get; }
    public float speed { private set; get; }
    public bool isMax { get { return quantity >= MAX; } }

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