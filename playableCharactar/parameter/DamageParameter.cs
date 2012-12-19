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
    /// �h��͂𖳎����邩
    /// </summary>
    private bool isIgnoreDeffence
    {
        get;
        set;
    }

    /// <summary>
    /// �_���[�W��
    /// </summary>
    public float damage
    {
        get { return moveParameter.speed; }
        set { moveParameter.speed = value; }
    }

    /// <summary>
    /// �_���[�W�̕���
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
    /// �L�����̃p�����[�^�����Ƀ_���[�W�v�Z
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