using UnityEngine;
using System.Collections;

public class CharacterChargeState : CharacterMoveState
{
	private const float MAX = 100F;
	private readonly string pushButton;
	
	private Charge charge
	{
		get;
		set;
	}
	
	public CharacterChargeState(Character parent, IGamePad pad, string push):base(parent,pad)
	{
        pushButton = push;
        charge = push == Button.A ? parameter.attackCharge : parameter.skillCharge;
        //チャージゲージウィンドウを呼び出す
        character.parameterWindow.CreateChargeParameterWindow(charge);
	}
	
	protected override void Init()
	{
		framecounter = new FrameCounter(16);
		fix = new MoveFix(0.5F);
	}
	
	public override System.Type Update()
	{
		var st = CheckOfKey();
		
		charge.Charging();
				
		return st;
	}
	
	protected override System.Type CheckOfKey()
	{
		Stick st = gamepad.pushStick;

        if (!gamepad.IsPush(pushButton))
        {
            return GetNextState();
        }
		
		if(st != Stick.None){
			SetDirectionByStick(st);
			Move();
			AnimationFrameUpdate();
		}
		
		return null;
	}

    private System.Type GetNextState()
    {
        if (pushButton == Button.A) return charge.isMax ? typeof(CharacterChargeBlowState) : typeof(CharacterBlowState);

        return charge.isMax ? typeof(CharacterChargeSkillState) : typeof(CharacterSkillState);
    }
}

