using UnityEngine;
using System.Collections;

public class ResultState : IState {

    private MainGameManager parent;
    FrameCounter frame;

    public int name { get { return (int)MainGameManager.STATENAME.Result; } }

    public ResultState(MainGameManager manager)
    {
        parent = manager;
        frame = new FrameCounter(300);
    }


    public int Update()
    {
        frame.Update();

        if (frame.IsCall) { parent.Retry(); }

        return (int)MainGameManager.STATENAME.Changeless;
    }
}
