using UnityEngine;
using System.Collections;

/// <summary>
/// MapChipNXͺΒp[^
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
        if (chipState != beforeState)
        {
            parent.animation.ChangeFrame(false);
        }
    }
}


/// <summary>
/// }bv`bvΜjΉσΤ
/// </summary>
public enum MAPCHIPSTATE : int
{
  /// <summary>
  /// ’jΉ
  /// </summary>
  Normal=0,
  /// <summary>
  /// ­΅jΉ
  /// </summary>
  Crash_S,
  /// <summary>
  /// ©ΘθjΉ
  /// </summary>
  Crach_M,
  /// <summary>
  /// εjBζκΘ’
  /// </summary>
  Crash
}