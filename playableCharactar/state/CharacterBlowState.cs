using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterBlowState : CharacterBaseState
    {

        public override int name
        {
            get { return (int)Character.STATENAME.Blow; }
        }
        private BlowLogic logic;
        public CharacterBlowState(Character parent)
            : base(parent)
        {
            framecounter = new FrameCounter(7);
            var move = new MoveParameter(character.frontDirection, 5F);
            var blow = (GameObject.Instantiate(AttackLibrary.GetInstance.blow) as GameObject)
                .GetComponent<NormalBlow>();

            blow.parent = character;
            blow.syncCounter = framecounter;
            SoundManager.Play(SoundManager.attackLight);

            logic = new BlowLogic(move, blow.gameObject, framecounter);
            parameter.invincibly.Start(7, false);
        }

        public override int Update()
        {
            framecounter.Update();

            CharacterMove();

            return (int)logic.Update();
        }

        private void CharacterMove()
        {
            character.transform.localPosition += logic.move.velocity;
        }
    }

    protected class BlowLogic
    {
        private GameObject blow;
        public MoveParameter move
        {
            get;
            set;
        }
        private bool isReturn;
        FrameCounter framecounter;
        public BlowLogic(MoveParameter m, GameObject target, FrameCounter sync)
        {
            move = m;

            blow = target;

            framecounter = sync;
        }

        public Character.STATENAME Update()
        {
            if (IsChangeTiming())
            {
                var nextState = isReturn ? Character.STATENAME.Stay : Character.STATENAME.Changeless;
                CheckCall();
                return nextState;
            }

            return Character.STATENAME.Changeless;
        }

        private void CheckCall()
        {
            if (!isReturn) ChangeDirection();
        }

        private bool IsChangeTiming()
        {
            if (blow == null)
            {
                return isReturn ? framecounter.IsCall :
                    true;
            }

            return framecounter.IsCall;
        }
        private void ChangeDirection()
        {
            move.direction += 180;
            isReturn = true;
            if (blow == null)
            {
                framecounter.ChangeCallTiming(framecounter.count);
            }
        }
    }
}