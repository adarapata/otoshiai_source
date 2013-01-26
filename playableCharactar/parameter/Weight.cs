using UnityEngine;
using System.Collections;

public class Weight
{
    public const float HEAVY = 65F;
    public const float MIDDLE = 50F;
    public const float LIGHT = 35F;
    private const float MIN = 10F;
    private const float MAX = 100F;

    readonly public float defaultWeight;
    private float m_quantity;

    public float quantity
    {
        get { return m_quantity; }
        set 
        {
            m_quantity = value;
            if (m_quantity > MAX) m_quantity = MAX;
            else if (m_quantity < MIN) m_quantity = MIN;
        }
    }

    public Weight(float weight)
    {
        defaultWeight = weight;
        quantity = defaultWeight;
    }

    static public Vector3 CalculateVelocityByWeight(MoveParameter param, Weight weight)
    {
        return param.velocity * (Weight.MIDDLE / weight.quantity);
    }

    /// <summary>
    /// ���g�̑̏d�����Ƀ}�b�v�`�b�v�ɗ^����_���[�W���v�Z����
    /// </summary>
    /// <returns></returns>
    public float DamageToMapChip()
    {
        //����Ă���l�̑̏d�����ȉ��Ȃ�ω��Ȃ�
        if (quantity <= MIDDLE) { return 0; }

        return quantity / MIDDLE;
    }
}

