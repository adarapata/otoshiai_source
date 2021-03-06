using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterBaseState : BaseState
    {
        public override int name
        {
            get { return 5; }
        }

        protected Character character
        {
            get;
            set;
        }
        new protected Character stateParent
        {
            get { return character; }
            set { character = value; }
        }
        protected CharacterParameter parameter
        {
            get { return character.parameter; }
            set { character.parameter = value; }
        }

        protected FrameCounter framecounter
        {
            get;
            set;
        }
        public CharacterBaseState(Character parent)
            : base(parent)
        {
            character = parent;
        }
    }
}
