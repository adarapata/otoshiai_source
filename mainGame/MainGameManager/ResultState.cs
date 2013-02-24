using UnityEngine;
using System.Collections;

public partial class MainGameManager : MonoBehaviour
{
    protected class ResultState : IState
    {

        private MainGameManager parent;
        FrameCounter frame;

        public int name { get { return (int)STATENAME.Result; } }

        public ResultState(MainGameManager manager)
        {
            parent = manager;
            frame = new FrameCounter(300);
        }


        public int Update()
        {
            frame.Update();

            if (frame.IsCall) { parent.Retry(); }

            return (int)STATENAME.Changeless;
        }
    }
}
