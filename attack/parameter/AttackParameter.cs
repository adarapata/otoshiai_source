using UnityEngine;
using System.Collections;

/// <summary>
/// �U���I�u�W�F�N�g�̃p�����[�^
/// </summary>
public class AttackParameter {
    /// <summary>
    /// �_���[�W
    /// </summary>
    public Damage damage
    {
        get;
        set;
    }

    public AttackLevel attackLevel
    {
        get;
        set;
    }


}

/// <summary>
/// �U�����x���̃N���X
/// </summary>
public class AttackLevel
{
    public const int MIN_LEVEL = 1;
    public const int MAX_LEVEL = 5;

    private int m_level;
    /// <summary>
    /// �U�����x��
    /// </summary>
    private int level
    {
        get { return m_level; }
        set
        {
            //�o���f�[�V���������Ă���
            if (value < MIN_LEVEL) { m_level = MIN_LEVEL; return; }
            if (value > MAX_LEVEL) { m_level = MAX_LEVEL; return; }
            m_level = value;
        }
    }

    /// <summary>
    /// �����x���̏ꍇ�A�s�k���肩
    /// </summary>
    private bool setOff
    {
        get;
        set;
    }

    public AttackLevel(int Level, bool SetOff)
    {
        level = Level;
        setOff = SetOff;
    }

    /// <summary>
    /// ����̃��x���Ɣ�r����
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    public bool CheckLevel(AttackLevel enemy)
    {
        int a = level - enemy.level;
        //���E�̏ꍇ�A�����̃��x�����P�����Čv�Z����
        if (setOff) a--;
        return a >= 0;
    }
}