using UnityEngine;
using System.Collections;

public class ReimuSkillState : CharacterSkillState {

    private Ofuda ofuda;
    public ReimuSkillState(Character parent):base(parent)
	{
        framecounter = new FrameCounter(10);
        CreateBullet();
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
        ofuda.SetTeamTransform(stateParent.baseParameter.team, stateParent.transform.parent);
        ofuda.attackParameter.damage = new Damage(30, false, 10, character.frontDirection, false);
        ofuda.transform.localPosition = stateParent.transform.localPosition;
        ofuda.baseParameter.moveParameter = new MoveParameter(character.frontDirection, 5F);

        SoundManager.Play(SoundManager.shot1);
    }
}
