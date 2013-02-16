using UnityEngine;
using System.Collections;

public class ResultState : IState {

    private MainGameManager parent;
    FrameCounter frame;
    public ResultState(MainGameManager manager)
    {
        parent = manager;
        frame = new FrameCounter(300);
    }


    public System.Type Update()
    {
        frame.Update();

        if (frame.IsCall) { parent.Retry(); }
        
        return null;
    }
}
