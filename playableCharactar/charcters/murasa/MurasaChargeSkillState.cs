using UnityEngine;
using System.Collections;

public class MurasaChargeSkillState : CharacterSkillState
{
    private Ikari ikari;
    public int name { get { return (int)Character.STATENAME.ChargeSkill; } }
    public MurasaChargeSkillState(Murasa parent)
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
        ikari = (GameObject.Instantiate(list.ikari) as GameObject).GetComponent<Ikari>();
        ikari.parent = character;
        ikari.Init();
        ikari.SetTransformParent();
        (character as Murasa).ikari = ikari.gameObject;
        SoundManager.Play(SoundManager.shot1);
    }
}
