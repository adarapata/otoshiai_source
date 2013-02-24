using UnityEngine;
using System.Collections;

public partial class MainGameManager : MonoBehaviour
{
    protected class PauseState : BaseState
    {

        public override int Update()
        {
            return base.Update();
        }

        public PauseState(BaseCharacter b)
            : base(b)
        { }
    }
}