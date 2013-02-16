using UnityEngine;
using System.Collections;

public class YugiSkillState  : CharacterSkillState {

    private Ikaring ika;
    public YugiSkillState(Character parent):base(parent)
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
        ika = (GameObject.Instantiate(list.ikaring) as GameObject).GetComponent<Ikaring>();
        ika.parent = character;
        ika.Init();
        ika.SetTransformParent();
        SoundManager.Play(SoundManager.shot1);
    }
}
