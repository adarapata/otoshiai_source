using UnityEngine;
using System.Collections;

/// <summary>
/// �}�b�v�`�b�v�̗̑�
/// </summary>
public class MapChipHP
{

    private readonly float max_hp;
    /// <summary>
    /// �ϋv�l
    /// </summary>
    public float strength
    {
        get;
        set;
    }

    /// <summary>
    /// �P�t���[���ӂ�̎��R������
    /// </summary>
    public float autoDeduct
    {
        get;
        set;
    }

    /// <summary>
    /// ���R�������邩�ǂ���
    /// </summary>
    public bool isAutoDeduct
    {
        get;
        set;
    }

    public bool isLive
    {
        get { return strength < 0; }
    }

    /// <summary>
    /// ���R�������Ȃ��ꍇ�̃R���X�g���N�^
    /// </summary>
    /// <param name="max"></param>
    public MapChipHP(float max)
    {
        max_hp = max;
        strength = max_hp;
        isAutoDeduct = false;
    }

    /// <summary>
    /// ���R�Ɍ�������ꍇ�̃R���X�g���N�^
    /// </summary>
    /// <param name="max"></param>
    /// <param name="autodeduct"></param>
    public MapChipHP(float max, float autodeduct)
    {
        max_hp = max;
        strength = max_hp;
        isAutoDeduct = true;
        autoDeduct = autodeduct;
    }

    public void Damage(float damage)
    {
        strength -= damage;
    }

    public bool Update()
    {
        if (isAutoDeduct) Damage(autoDeduct);

        return isLive;
    }


    /// <summary>
    /// ���݂�HP�����ɔj����Ԃ�Ԃ�
    /// </summary>
    /// <param name="beforeState"></param>
    /// <returns></returns>
    public MAPCHIPSTATE GetNewState()
    {
        int rate = (int)((strength / max_hp) * 100F);

        if (rate <= 0) return MAPCHIPSTATE.Crash;
        if (rate <= 20) return MAPCHIPSTATE.Crach_M;
        if (rate <= 50) return MAPCHIPSTATE.Crash_S;
        return MAPCHIPSTATE.Normal;
    }
}