using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    public class MoveFix
    {
        private readonly float m_quantity;
        public float quantity
        {
            get { return m_quantity; }
        }
        public MoveFix(float fix)
        {
            m_quantity = fix;
        }
    }

    /// <summary>
    /// プレイアブルキャラクターの移動状態クラス
    /// </summary>
    protected class CharacterMoveState : CharacterBaseState
    {


        protected MoveFix fix;
        protected IGamePad gamepad;
        protected CharacterAnimationController animation;

        public override int name
        {
            get { return (int)STATENAME.Move; }
        }

        public CharacterMoveState(Character parent, IGamePad pad)
            : base(parent)
        {
            gamepad = pad;
            animation = character.animation as CharacterAnimationController;
            Init();
        }

        virtual protected void Init()
        {
            fix = new MoveFix(1F);
            framecounter = new FrameCounter(8);
        }

        public override int Update()
        {
            var newState = CheckOfKey();

            Move();

            StaminaRecover();

            AnimationFrameUpdate();

            return (int)newState;
        }


        virtual protected STATENAME CheckOfKey()
        {
            Stick st = gamepad.pushStick;

            if (st == Stick.None) return STATENAME.Stay;

            if (gamepad.GetChargeButton != null) return STATENAME.Charge;

            SetDirectionByStick(st);

            if (gamepad.IsPush(Button.D) && CharacterDashMoveState.IsParmittion(parameter.stamina))
                return STATENAME.DashMove;

            return STATENAME.Changeless;
        }

        protected void Move()
        {
            character.MovePosition(fix);
        }

        private void StaminaRecover()
        {
            parameter.stamina.Recovery();
        }

        protected void AnimationFrameUpdate()
        {
            framecounter.Update();
            if (framecounter.IsCall) animation.ChangeFrame(true);
        }

        protected void SetDirectionByStick(Stick stick)
        {
            character.baseParameter.moveParameter.direction = (int)stick;
            if (!IsLockDirection) animation.SetPatternByStick(stick);
        }

        /// <summary>
        /// 向き固定ボタンを押しているかどうか
        /// </summary>
        private bool IsLockDirection
        {
            get { return gamepad.IsPush(Button.Lock); }
        }
    }
}