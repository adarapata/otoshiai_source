using UnityEngine;
using System.Collections;

public class CharacterChargeBlowState : CharacterBaseState {

    private BlowLogic logic;
	public CharacterChargeBlowState(Character parent):base(parent)
	{
        framecounter = new FrameCounter(7);
        var move = new MoveParameter(character.frontDirection, 7F);
        var blow = (GameObject.Instantiate(AttackLibrary.GetInstance.chargeBlow) as GameObject)
            .GetComponent<ChargeBlow>();

        blow.parent = character;
        blow.syncCounter = framecounter;
        SoundManager.Play(SoundManager.attackHeavy);

        logic = new BlowLogic(move, blow.gameObject, framecounter);
        parameter.invincibly.Start(7, false);
	}
	
	public override System.Type Update()
	{
        framecounter.Update();

        CharacterMove();

        return logic.Update();
    }

    private void CharacterMove()
    {
        character.transform.localPosition += logic.move.velocity;
    }
}
