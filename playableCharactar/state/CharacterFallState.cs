using UnityEngine;
using System.Collections;

public partial class Character : BaseCharacter
{
    protected class CharacterFallState : CharacterBaseState
    {
        private float scale = 0.95F;

        public override int name
        {
            get { return (int)STATENAME.Fall; }
        }

        public CharacterFallState(Character parent)
            : base(parent)
        {
            framecounter = new FrameCounter(60);
        }

        public override int Update()
        {
            var state = FrameUpdate();

            Falling();

            return (int)state;
        }

        private void Falling()
        {
            Vector3 fall = character.transform.localScale;
            fall.x *= scale; fall.y *= scale;
            character.transform.localScale = fall;
        }

        private STATENAME FrameUpdate()
        {
            framecounter.Update();
            if (framecounter.IsCall) { SoundManager.Play(SoundManager.death); }
            return framecounter.IsCall ? STATENAME.Dead : STATENAME.Changeless;
        }
    }
}