using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterSkillState : CharacterBaseState
    {

        public override int name
        {
            get { return (int)Character.STATENAME.Skill; }
        }

        public CharacterSkillState(Character parent)
            : base(parent)
        {

        }

        public override int Update()
        {
            return (int)Character.STATENAME.Stay;
        }
    }
}