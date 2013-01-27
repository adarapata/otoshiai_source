using UnityEngine;
using System.Collections;

public class ReimuSkillState : CharacterSkillState {

    private Ofuda ofuda;
    public ReimuSkillState(Character parent):base(parent)
	{
        framecounter = new FrameCounter(10);
        CreateBullet();
        parameter.weight.quantity++;
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
        ofuda = (GameObject.Instantiate(list.ofuda) as GameObject).GetComponent<Ofuda>();
        ofuda.parent = character;

        SoundManager.Play(SoundManager.shot1);
    }
}
