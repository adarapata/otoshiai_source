using UnityEngine;
using System.Collections;

public class HitStop
{
    public int quantity
    {
        get;
        set;
    }

    public HitStop(int stopTime)
    {
        quantity = stopTime;
    }

    public void Update()
    {
        quantity--;
    }

    public bool isEnd
    {
        get { return quantity <= 0; }
    }
}
