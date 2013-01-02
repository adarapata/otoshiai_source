using UnityEngine;
using System.Collections;

/// <summary>
/// マップチップの体力
/// </summary>
public class MapChipHP
{

    private readonly float max_hp;
    /// <summary>
    /// 耐久値
    /// </summary>
    public float strength
    {
        get;
        set;
    }

    /// <summary>
    /// １フレーム辺りの自然減少量
    /// </summary>
    public float autoDeduct
    {
        get;
        set;
    }

    /// <summary>
    /// 自然減少するかどうか
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
    /// 自然減少しない場合のコンストラクタ
    /// </summary>
    /// <param name="max"></param>
    public MapChipHP(float max)
    {
        max_hp = max;
        strength = max_hp;
        isAutoDeduct = false;
    }

    /// <summary>
    /// 自然に減少する場合のコンストラクタ
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
    /// 現在のHPを元に破損状態を返す
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