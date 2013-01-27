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
	
	public override System.Type Update()
	{

        framecounter.Update();

        return framecounter.IsCall ? typeof(CharacterStayState) : null;
	}

    private void CreateBullet()
    {
        var list = AttackLibrary.GetInstance;
        amulet = (GameObject.Instantiate(list.amuret) as GameObject).GetComponent<HomingAmulet>();
        amulet.parent = character;

        SoundManager.Play(SoundManager.amulet);
    }
}
