using UnityEngine;
using System.Collections;

public partial class Yugi : Character
{
    protected partial class YugiChargeSkillState : CharacterChargeSkillState
    {
        protected partial class WaitState : BaseState
        {
            public override int name
            {
                get
                {
                    return (int)SUBSTATENAME.Wait;
                }
            }

            FrameCounter frame;
            YugiChargeSkillState parent;
            public WaitState(BaseCharacter parent, YugiChargeSkillState parentState)
                : base(parent)
            {
                frame = new FrameCounter(180);
                this.parent = parentState;
            }

            public override int Update()
            {
                frame.Update();

                if (frame.IsCall) { parent.ChangeState(SUBSTATENAME.Shot); }
                return (int)SUBSTATENAME.Changeless;
            }
        }
    }
}