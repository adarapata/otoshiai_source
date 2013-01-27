using UnityEngine;
using System.Collections;

public class CharacterBlowState : CharacterBaseState {

    private BlowLogic logic;
	public CharacterBlowState(Character parent):base(parent)
	{
        framecounter = new FrameCounter(7);
        var move = new MoveParameter(character.frontDirection, 5F);
        var blow = (GameObject.Instantiate(AttackLibrary.GetInstance.blow) as GameObject)
            .GetComponent<NormalBlow>();

        blow.parent = character;
        blow.syncCounter = framecounter;
        SoundManager.Play(SoundManager.attackLight);

        logic = new BlowLogic(move, blow.gameObject, framecounter);
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

public class BlowLogic
{
    private GameObject blow;
    public MoveParameter move
    {
        get;
        set;
    }
    private bool isReturn;
    FrameCounter framecounter;
	public BlowLogic(MoveParameter m, GameObject target, FrameCounter sync)
	{
        move = m;

        blow = target;

        framecounter = sync;
	}
	
	public System.Type Update()
	{
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
            framecounter.ChangeCallTiming(framecounter.count);
        }
    }
}
