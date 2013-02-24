using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterHitStopState : CharacterBaseState
    {
        private IGamePad gamepad;
        private Damage damage
        {
            get;
            set;
        }

        public override int name
        {
            get { return (int)STATENAME.HitStop; }
        }

        private HitStop hitstop
        {
            get { return damage.hitStop; }
        }

        public CharacterHitStopState(Character parent, IGamePad pad, Damage damages)
            : base(parent)
        {
            gamepad = pad;
            this.damage = damages;


            if (damage.damageParameter.damage >= 20F) SoundManager.Play(SoundManager.hitHeavy);
            else SoundManager.Play(SoundManager.hitLight);
        }

        public override int Update()
        {
            hitstop.Update();
            if (hitstop.isEnd) { return (int)STATENAME.Damage; }

            CharacterShake();
            return (int)STATENAME.Changeless;
        }

        /// <summary>
        /// 左右に揺らしてダメージっぽいエフェクトをかける
        /// </summary>
        private void CharacterShake()
        {
            var pos = character.transform.localPosition;
            pos.x += hitstop.quantity % 2 == 0 ? 2 : -2;
            character.transform.localPosition = pos;
        }
    }
}
