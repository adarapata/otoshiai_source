using UnityEngine;
using System.Collections;

public partial class Yugi : Character
{
    protected class YugiChargeSkillState : CharacterChargeSkillState
    {
        public enum SUBSTATENAME
        {
            Wait = 0,
            Shot,
            Changeless = GENERICSTATENAME.Changeless
        }

        class WaitState : BaseState
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
        class ShotState : BaseState
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

        private GameObject circle;
        private IState childState;
        private Oodama oodama;
        public YugiChargeSkillState(Character parent)
            : base(parent)
        {
            circle = Resources.Load("Objects/other/circle") as GameObject;
            var obj = GameObject.Instantiate(circle) as GameObject;
            obj.transform.parent = parent.transform;
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<Circle>().parent = character;

            parameter.stamina.quantity -= 10;

            childState = new WaitState(parent, this);

            SoundManager.Play(SoundManager.charge);
        }

        public override int Update()
        {
            var nextState = childState.Update();

            if (nextState != (int)SUBSTATENAME.Changeless) { return (int)STATENAME.Stay; }

            return (int)STATENAME.Changeless;
        }

        public void ChangeState(SUBSTATENAME nextState)
        {
            if (nextState == SUBSTATENAME.Shot)
            {
                childState = new ShotState(stateParent, this);
                character.parameter.invincibly.Start(180, false);
            }
        }

        public void CreateBullet()
        {
            var list = AttackLibrary.GetInstance;
            oodama = (GameObject.Instantiate(list.oodama) as GameObject).GetComponent<Oodama>();
            oodama.parent = character;

            MoveParameter param = new MoveParameter(Random.Range(190, 250), Random.Range(20, 50) * 0.1F);
            Damage da = new Damage(30, false, 25, param.direction, false);
            oodama.Init();
            oodama.transform.localPosition = new Vector3(500, 400);
            oodama.SetMoveDirection(param, da);
            oodama.sprite.color = new Color(1, 1, 1, 0.5F);
            SoundManager.Play(SoundManager.shot2);
        }
    }
}