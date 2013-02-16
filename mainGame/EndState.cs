using UnityEngine;
using System.Collections;

public class EndState : IState
{

    private MainGameManager parent;
    FrameCounter frame;
    public EndState(MainGameManager manager)
    {
        parent = manager;
        frame = new FrameCounter(180);
    }


    public System.Type Update()
    {
        frame.Update();

        if (frame.IsCall) { parent.BackSelectScene(); }

        return null;
    }
}
