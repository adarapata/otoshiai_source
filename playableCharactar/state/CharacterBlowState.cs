using UnityEngine;
using System.Collections;

public class CharacterBlowState : CharacterBaseState {

    private NormalBlow blow;
    private MoveParameter move;
    private bool isReturn;
	public CharacterBlowState(Character parent):base(parent)
	{
        framecounter = new FrameCounter(7);
        move = new MoveParameter(character.frontDirection, 5F);

        blow = (GameObject.Instantiate(AttackLibrary.GetInstance.blow) as GameObject)
            .GetComponent<NormalBlow>();

        blow.parent = character;
        blow.syncCounter = framecounter;
        SoundManager.Play(SoundManager.attackLight);
	}
	
	public override System.Type Update()
	{

        framecounter.Update();

        CharacterMove();

        if (IsChangeTiming())
        {
            System.Type nextState = isReturn ? typeof(CharacterStayState) : null;
            CheckCall();
            return nextState;
        }

        return null;
	}

    private void CheckCall()
    {
        if (!isReturn) ChangeDirection();
    }
    private void CharacterMove()
    {
        character.transform.localPosition += move.velocity;
    }

    private bool IsChangeTiming()
    {
        if (blow == null)
        {
            return isReturn ? framecounter.IsCall :
                true;
        }

        return framecounter.IsCall;
    }
    private void ChangeDirection()
    {
        move.direction += 180;
        isReturn = true;
        if (blow == null)
        {
            framecounter = new FrameCounter(framecounter.count);
        }
    }
}

