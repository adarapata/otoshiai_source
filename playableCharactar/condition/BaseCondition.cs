using UnityEngine;
using System.Collections;

/// <summary>
/// キャラのコンディションの基盤クラス
/// </summary>
public abstract class BaseCondition {
    protected Character parent
    {
        get;
        set;
    }
    protected FrameCounter framecounter
    {
        get;
        set;
    }

    public BaseCondition(Character chara)
    {
        parent = chara;
    }

    virtual public BaseCondition Update()
    {
        framecounter.Update();
        return null;
    }
}
