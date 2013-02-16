using UnityEngine;
using System.Collections;

public class MurasaChargeSkillState : CharacterSkillState
{

    private Ikari ikari;
    public MurasaChargeSkillState(Murasa parent)
        : base(parent)
    {
        framecounter = new FrameCounter(10);
        CreateBullet();
        parameter.stamina.quantity -= 10;
    }

    public override System.Type Update()
    {
        framecounter.Update();

        return framecounter.IsCall ? typeof(CharacterStayState) : null;
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
