using UnityEngine;
using System.Collections;

public class Stamina
{
    const int MAX = 100;

    private float m_quantity;

    public float quantity
    {
        get { return m_quantity; }
        set
        {
            m_quantity = value;
            if (m_quantity > MAX) m_quantity = MAX;
            else if (m_quantity < 0) m_quantity = 0;
        }
    }

    public float recoveryRate
    {
        get;
        set;
    }
    /// <summary>
    /// スタミナ回復
    /// </summary>
    /// <param name="rate"></param>
    public void Recovery(float rate)
    {
        quantity += rate;
    }

    public void Recovery()
    {
        Recovery(recoveryRate);
    }

}