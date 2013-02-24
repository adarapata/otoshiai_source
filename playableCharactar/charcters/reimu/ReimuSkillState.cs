using UnityEngine;
using System.Collections;

public partial class Reimu : Character
{
    protected class ReimuSkillState : CharacterSkillState
    {

        private Ofuda ofuda;
        public ReimuSkillState(Character parent)
            : base(parent)
        {
            framecounter = new FrameCounter(10);
            CreateBullet();
            parameter.stamina.quantity -= 10;
        }

        public override int Update()
        {

            framecounter.Update();

            return (int)(framecounter.IsCall ? STATENAME.Stay : STATENAME.Changeless);
        }

        private void CreateBullet()
        {
            var list = AttackLibrary.GetInstance;
            ofuda = (GameObject.Instantiate(list.ofuda) as GameObject).GetComponent<Ofuda>();
            ofuda.parent = character;
            ofuda.Init();
            ofuda.SetTransformParent();
            SoundManager.Play(SoundManager.shot1);
        }
    }
}