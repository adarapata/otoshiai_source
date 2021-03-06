using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterChargeSkillState : CharacterBaseState
    {

        public override int name
        {
            get { return (int)STATENAME.ChargeSkill; }
        }
        public CharacterChargeSkillState(Character parent)
            : base(parent)
        {

        }

        public override int Update()
        {
            return (int)STATENAME.Stay;
        }
    }
}