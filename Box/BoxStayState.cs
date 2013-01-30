using UnityEngine;
using System.Collections;

public class BoxStayState : BaseState {

    private FrameCounter counter;
    public BoxStayState(BaseBox parent)
        : base(parent)
    {
        counter = new FrameCounter(10000);
    }

    public override System.Type Update()
    {
        counter.Update();

        return counter.IsCall ? typeof(BaseState) : null;
    }
}
