using UnityEngine;
using System.Collections;

/// <summary>
/// �L�����̃R���f�B�V�����̊�ՃN���X
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
