using UnityEngine;
using System.Collections;

public partial class Yugi : Character
{
    protected partial class YugiChargeSkillState : CharacterChargeSkillState
    {
        protected class ShotState : BaseState
        {
            public override int name
            {
                get
                {
                    return (int)SUBSTATENAME.Shot;
                }
            }

            FrameCounter frame, shotInterval;
            YugiChargeSkillState parent;
            public ShotState(BaseCharacter parent, YugiChargeSkillState parentState)
                : base(parent)
            {
                this.parent = parentState;
                frame = new FrameCounter(180);
                shotInterval = new FrameCounter(3);
            }

            public override int Update()
            {
                frame.Update();
                shotInterval.Update();

                if (shotInterval.IsCall) { parent.CreateBullet(); }

                return (int)(frame.IsCall ? SUBSTATENAME.Shot : SUBSTATENAME.Changeless);
            }
        }
    }
}