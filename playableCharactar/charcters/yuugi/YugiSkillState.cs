using UnityEngine;
using System.Collections;

public partial class Yugi : Character
{
    protected class YugiSkillState : CharacterSkillState
    {

        private Ikaring ika;
        public YugiSkillState(Character parent)
            : base(parent)
        {
            framecounter = new FrameCounter(10);
            CreateBullet();
            parameter.stamina.quantity -= 10;
        }

        public override int Update()
        {

            framecounter.Update();

            return (int)(framecounter.IsCall ? Character.STATENAME.Stay : Character.STATENAME.Changeless);
        }

        private void CreateBullet()
        {
            var list = AttackLibrary.GetInstance;
            ika = (GameObject.Instantiate(list.ikaring) as GameObject).GetComponent<Ikaring>();
            ika.parent = character;
            ika.Init();
            ika.SetTransformParent();
            SoundManager.Play(SoundManager.shot1);
        }
    }
}