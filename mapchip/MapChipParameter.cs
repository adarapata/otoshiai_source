using UnityEngine;
using System.Collections;

/// <summary>
/// MapChip�N���X�����p�����[�^
/// </summary>
public class MapChipParameter {

    private MapChip parent;

    public MapChipHP hp
    {
        get;
        set;
    }

    public MAPCHIPSTATE chipState
    {
        get;
        set;
    }

    public MapChipParameter(MapChip Parent, MapChipHP Hp)
    {
        parent = Parent;
        hp = Hp;
    }

    public void Update()
    {
        hp.Update();

        CheckChipState();
    }

    private void CheckChipState()
    {
        var beforeState = chipState;
        chipState = hp.GetNewState();

        //�O��Ə�Ԃ��Ⴄ=���ꂽ
        if (chipState != beforeState)
        {
            //�Ђъ��ꉹ���Đ�
            SoundManager.Play(SoundManager.map[(int)beforeState]);
            parent.animation.ChangeFrame(false);
        }
    }
}


/// <summary>
/// �}�b�v�`�b�v�̔j�����
/// </summary>
public enum MAPCHIPSTATE : int
{
  /// <summary>
  /// ���j��
  /// </summary>
  Normal=0,
  /// <summary>
  /// �����j��
  /// </summary>
  Crash_S,
  /// <summary>
  /// ���Ȃ�j��
  /// </summary>
  Crach_M,
  /// <summary>
  /// ��j�B���Ȃ�
  /// </summary>
  Crash
}