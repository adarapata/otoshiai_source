using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterDeadState : CharacterBaseState
    {
        public override int name
        {
            get { return (int)STATENAME.Dead; }
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="parent"></param>
        public CharacterDeadState(Character parent)
            : base(parent)
        {

        }

        public override int Update()
        {
            return (int)STATENAME.Changeless;
        }
    }
}