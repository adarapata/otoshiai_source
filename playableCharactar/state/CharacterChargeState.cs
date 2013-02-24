using UnityEngine;
using System.Collections;

public class CharacterChargeState : CharacterMoveState
{
	private const float MAX = 100F;
	private readonly string pushButton;

    public override int name
    {
        get { return (int)Character.STATENAME.Charge; }
    }

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
	
	public override int Update()
	{
		var st = CheckOfKey();
		
		charge.Charging();
				
		return (int)st;
	}
	
	protected override Character.STATENAME CheckOfKey()
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

        return Character.STATENAME.Changeless;
	}

    private Character.STATENAME GetNextState()
    {
        if (pushButton == Button.A) return charge.isMax ? Character.STATENAME.ChargeBlow : Character.STATENAME.Blow;

        return charge.isMax ? Character.STATENAME.ChargeSkill : Character.STATENAME.Skill;
    }
}

