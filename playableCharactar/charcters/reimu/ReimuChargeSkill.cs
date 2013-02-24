using UnityEngine;
using System.Collections;

public class ReimuChargeSkillState : CharacterChargeSkillState {

    private HomingAmulet amulet;
    public ReimuChargeSkillState(Character parent):base(parent)
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
        amulet = (GameObject.Instantiate(list.amuret) as GameObject).GetComponent<HomingAmulet>();
        amulet.parent = character;
        amulet.Init();
        amulet.SetTransformParent();
        SoundManager.Play(SoundManager.amulet);
    }
}
