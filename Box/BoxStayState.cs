using UnityEngine;
using System.Collections;

public partial class BaseBox : BaseCharacter
{
    protected class BoxStayState : BaseState
    {
        public override int name
        {
            get
            {
                return (int)STATENAME.Stay;
            }
        }

        private FrameCounter counter;
        public BoxStayState(BaseBox parent)
            : base(parent)
        {
            counter = new FrameCounter(10000);
        }

        public override int Update()
        {
            counter.Update();

            return (int)(counter.IsCall ? STATENAME.Stay : STATENAME.Changeless);
        }
    }
}