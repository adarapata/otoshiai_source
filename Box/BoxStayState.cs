using UnityEngine;
using System.Collections;

public class BoxStayState : BaseState {

    private FrameCounter counter;
    public BoxStayState(BaseBox parent)
        : base(parent)
    {
        counter = new FrameCounter(10000);
    }

    public override int Update()
    {
        counter.Update();
        
        return (int)(counter.IsCall ? BaseBox.STATENAME.Stay : BaseBox.STATENAME.Changeless);
    }
}
