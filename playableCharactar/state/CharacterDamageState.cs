using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterDamageState : CharacterBaseState
    {
        public override int name
        {
            get { return (int)Character.STATENAME.Damage; }
        }

        private DamageParameter damageParameter
        {
            get;
            set;
        }
        public CharacterDamageState(Character parent, DamageParameter dParameter)
            : base(parent)
        {
            damageParameter = dParameter;
            damageParameter.DamageCalculate(character.parameter);
        }

        public override int Update()
        {
            var state = BlowOffDamage();
            return (int)state;
        }

        /// <summary>
        /// ������я���
        /// </summary>
        /// <returns></returns>
        private Character.STATENAME BlowOffDamage()
        {
            character.collider.enabled = false;
            character.transform.localPosition += damageParameter.velocity;
            damageParameter.damage--;
            if (damageParameter.damage < 0)
            {
                CreateBlinkAndInvincibly(60);
                character.parameter.damage = null;
                character.collider.enabled = true;
                return Character.STATENAME.Stay;
            }

            return Character.STATENAME.Changeless;
        }

        /// <summary>
        /// �_���[�W�I����̖��G��ԁ��_�ł̐ݒ�
        /// </summary>
        /// <param name="time"></param>
        private void CreateBlinkAndInvincibly(int time)
        {
            character.baseParameter.blinkParameter.Start(time, false);
            parameter.invincibly.Start(time, false);
        }
    }
}
