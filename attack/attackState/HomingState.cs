using UnityEngine;
using System.Collections;

/// <summary>
/// 対象のオブジェクトまでホーミングする汎用State
/// </summary>
public class HomingState : BaseState {
    public enum HOMINGLEVEL
    {
        Low = 1,
        Middole = 3,
        High = 10,
    }
    public class Options
    {
        public HOMINGLEVEL level;
        public int time;
        public int interval;
    }

    private Transform target;
    private FrameCounter framecount;
    private HOMINGLEVEL homingLevel;
    private readonly int interval;

    public HomingState(BaseAttack parent, Transform _target, Options option)
        : base(parent)
    {
        target = _target;
        framecount = new FrameCounter(option.time);
        homingLevel = option.level;
        interval = option.interval;
    }

    public override System.Type Update()
    {
        framecount.Update();
        Move();

        return framecount.IsCall ? typeof(BaseState) : null;
    }

    private void Move()
    {
        if (framecount.count % interval == 0)
        {
            int dir = GetHoming();
            stateParent.baseParameter.moveParameter.direction += dir;
        }
        stateParent.transform.localPosition += stateParent.baseParameter.moveParameter.velocity;
    }
    private int GetHoming()
    {
        Vector2 pos = target.localPosition - stateParent.transform.localPosition;
        PolarCoordinates pol = new PolarCoordinates { direction = stateParent.baseParameter.moveParameter.direction, speed = 1 };
        Vector2 normal = pol.ConvertToPolar();
        float cross = normal.Ccw(pos);
        return cross > 0 ? (int)homingLevel : -(int)homingLevel;
    }
}
