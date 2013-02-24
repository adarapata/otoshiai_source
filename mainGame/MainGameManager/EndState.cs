using UnityEngine;
using System.Collections;

public partial class MainGameManager : MonoBehaviour
{
    public class EndState : IState
    {
        private MainGameManager parent;
        FrameCounter frame;

        public int name { get { return (int)STATENAME.End; } }

        public EndState(MainGameManager manager)
        {
            parent = manager;
            frame = new FrameCounter(180);
        }


        public int Update()
        {
            frame.Update();

            if (frame.IsCall) { parent.BackSelectScene(); }

            return (int)STATENAME.Changeless;
        }
    }
}
