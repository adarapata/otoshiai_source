using UnityEngine;
using System.Collections;

public partial class Yugi : Character
{
    protected partial class YugiChargeSkillState : CharacterChargeSkillState
    {
        public enum SUBSTATENAME
        {
            Wait = 0,
            Shot,
            Changeless = GENERICSTATENAME.Changeless
        }

        private GameObject circle;
        private IState childState;
        private Oodama oodama;
        public YugiChargeSkillState(Character parent)
            : base(parent)
        {
            circle = Resources.Load("Objects/other/circle") as GameObject;
            var obj = GameObject.Instantiate(circle) as GameObject;
            obj.transform.parent = parent.transform;
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<Circle>().parent = character;

            parameter.stamina.quantity -= 10;

            childState = new WaitState(parent, this);

            SoundManager.Play(SoundManager.charge);
        }

        public override int Update()
        {
            var nextState = childState.Update();

            if (nextState != (int)SUBSTATENAME.Changeless) { return (int)STATENAME.Stay; }

            return (int)STATENAME.Changeless;
        }

        public void ChangeState(SUBSTATENAME nextState)
        {
            if (nextState == SUBSTATENAME.Shot)
            {
                childState = new ShotState(stateParent, this);
                character.parameter.invincibly.Start(180, false);
            }
        }

        public void CreateBullet()
        {
            var list = AttackLibrary.GetInstance;
            oodama = (GameObject.Instantiate(list.oodama) as GameObject).GetComponent<Oodama>();
            oodama.parent = character;

            MoveParameter param = new MoveParameter(Random.Range(190, 250), Random.Range(20, 50) * 0.1F);
            Damage da = new Damage(30, false, 25, param.direction, false);
            oodama.Init();
            oodama.transform.localPosition = new Vector3(500, 400);
            oodama.SetMoveDirection(param, da);
            oodama.sprite.color = new Color(1, 1, 1, 0.5F);
            SoundManager.Play(SoundManager.shot2);
        }
    }
}