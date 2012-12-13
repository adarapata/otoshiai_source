using UnityEngine;
using System.Collections;

/// <summary>
/// プレイアブルキャラクターの移動状態クラス
/// </summary>
public class PlayableCharacterMoveState : PlayableCharacterBaseState
{
	public class MoveFix
	{
		private readonly float m_quantity;
		public float quantity
		{
			get { return m_quantity; }
		}
		public MoveFix(float fix)
		{
			m_quantity = fix;
		}
	}
	
	
	protected MoveFix fix;
	protected IGamePad gamepad;
	protected CharacterAnimationController animation;
	
	public PlayableCharacterMoveState(PlayableCharacter parent, IGamePad pad):base(parent)
	{
		gamepad = pad;
		animation = character.animation as CharacterAnimationController;
		Init();
	}
	
	virtual protected void Init()
	{
		fix = new MoveFix(1F);
		framecounter = new FrameCounter(8);
	}
	
	public override System.Type Update()
	{
		var newState = CheckOfKey();
		
		Move();
		
		StaminaRecover();
		
		AnimationFrameUpdate();
		
		return newState;
	}
	
	
	virtual protected System.Type CheckOfKey()
	{
		Stick st = gamepad.pushStick;
		
		if(st == Stick.None)return typeof(PlayableCharacterStayState);
		
		if(gamepad.IsPush(Button.A))return typeof(PlayableCharacterChargeState);
		if(gamepad.IsPush(Button.B))return typeof(PlayableCharacterChargeState);
		
		SetDirectionByStick(st);
		
		if(gamepad.IsPush(Button.D) && PlayableCharacterDashMoveState.IsParmittion(parameter.stamina))
			return typeof(PlayableCharacterDashMoveState);
		
		return null;
	}
	
	protected void Move()
	{
		character.MovePosition(fix);
	}
	
	private void StaminaRecover()
	{
		parameter.stamina.Recovery();
	}
	
	protected void AnimationFrameUpdate()
	{
		framecounter.Update();
		if(framecounter.IsCall)animation.ChangeFrame(true);
	}
	
	protected void SetDirectionByStick(Stick stick)
	{

		character.baseParameter.moveParameter.direction = (int)stick;
		animation.SetPatternByStick(stick);
	}
}

