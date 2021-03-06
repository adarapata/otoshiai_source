using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterStayState : CharacterBaseState
    {

        private IGamePad gamepad;

        public override int name
        {
            get { return (int)STATENAME.Stay; }
        }

        public CharacterStayState(Character parent, IGamePad pad)
            : base(parent)
        {
            gamepad = pad;
        }

        public override int Update()
        {
            StaminaRecover();
            return (int)CheckKeyState();
        }

        private STATENAME CheckKeyState()
        {
            var stick = gamepad.pushStick;

            if (gamepad.GetChargeButton != null) return STATENAME.Charge;

            if (stick == Stick.None) return STATENAME.Changeless;

            return GetStateWhenPushStick();
        }

        private STATENAME GetStateWhenPushStick()
        {
            if (gamepad.IsPush(Button.D) && CharacterDashMoveState.IsParmittion(parameter.stamina)) return STATENAME.DashMove;
            return STATENAME.Move;
        }

        private void StaminaRecover()
        {
            parameter.stamina.Recovery();
        }
    }
}