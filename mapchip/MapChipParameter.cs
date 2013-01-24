using UnityEngine;
using System.Collections;

/// <summary>
/// MapChipクラスが持つパラメータ
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

        //前回と状態が違う=割れた
        if (chipState != beforeState)
        {
            //ひび割れ音を再生
            SoundManager.Play(SoundManager.map[(int)beforeState]);
            parent.animation.ChangeFrame(false);
        }
    }
}


/// <summary>
/// マップチップの破損状態
/// </summary>
public enum MAPCHIPSTATE : int
{
  /// <summary>
  /// 未破損
  /// </summary>
  Normal=0,
  /// <summary>
  /// 少し破損
  /// </summary>
  Crash_S,
  /// <summary>
  /// かなり破損
  /// </summary>
  Crach_M,
  /// <summary>
  /// 大破。乗れない
  /// </summary>
  Crash
}