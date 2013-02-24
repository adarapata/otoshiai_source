using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterDashMoveState : CharacterMoveState
    {
        private const float PARMIT_STAMINA = 5F;
        private const float CONSUMPTION = 0.5F;

        public override int name
        {
            get { return (int)STATENAME.DashMove; }
        }

        public CharacterDashMoveState(Character parent, IGamePad pad)
            : base(parent, pad)
        {

        }

        protected override void Init()
        {
            framecounter = new FrameCounter(4);
            fix = new MoveFix(2F);
        }

        public override int Update()
        {
            var newState = CheckOfKey();

            Move();

            StaminaUse();

            AnimationFrameUpdate();

            return (int)newState;
        }

        protected override STATENAME CheckOfKey()
        {
            Stick st = gamepad.pushStick;

            if (st == Stick.None) return STATENAME.Stay;

            if (gamepad.IsPush(Button.A) | gamepad.IsPush(Button.B)) return STATENAME.Charge;

            SetDirectionByStick(st);

            if (!gamepad.IsPush(Button.D) || parameter.stamina.quantity < CONSUMPTION)
                return STATENAME.Move;

            return STATENAME.Changeless;
        }

        private void StaminaUse()
        {
            parameter.stamina.quantity -= CONSUMPTION;
        }

        static public bool IsParmittion(Stamina stamina)
        {
            return stamina.quantity > PARMIT_STAMINA;
        }
    }
}