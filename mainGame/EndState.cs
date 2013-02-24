using UnityEngine;
using System.Collections;

public class EndState : IState
{
    private MainGameManager parent;
    FrameCounter frame;

    public int name { get { return (int)MainGameManager.STATENAME.End; } }

    public EndState(MainGameManager manager)
    {
        parent = manager;
        frame = new FrameCounter(180);
    }


    public int Update()
    {
        frame.Update();

        if (frame.IsCall) { parent.BackSelectScene(); }

        return (int)MainGameManager.STATENAME.Changeless;
    }
}
