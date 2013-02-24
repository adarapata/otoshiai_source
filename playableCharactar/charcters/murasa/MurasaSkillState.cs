using UnityEngine;
using System.Collections;

public partial class Murasa : Character
{
    protected class MurasaSkillState : CharacterSkillState
    {

        private Shibuki shibuki;
        public int name { get { return (int)STATENAME.Skill; } }
        public MurasaSkillState(Character parent)
            : base(parent)
        {
            framecounter = new FrameCounter(20);
            parameter.stamina.quantity -= 10;
        }

        public override int Update()
        {

            framecounter.Update();

            if (framecounter.count % 3 == 0) { CreateBullet(); }


            return (int)(framecounter.IsCall ? STATENAME.Stay : STATENAME.Changeless);
        }

        private void CreateBullet()
        {
            var list = AttackLibrary.GetInstance;
            shibuki = (GameObject.Instantiate(list.shibuki) as GameObject).GetComponent<Shibuki>();
            shibuki.parent = character;
            shibuki.Init();

            shibuki.SetTransformParent();

            MoveParameter param = new MoveParameter(character.frontDirection + Random.Range(-25, 25), Random.Range(2F, 4F));
            Damage d = new Damage(30, true, 5, param.direction, false);
            shibuki.SetMoveDirection(param, d);
            SoundManager.Play(SoundManager.shot1);
        }
    }
}
