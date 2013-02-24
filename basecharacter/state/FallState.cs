using UnityEngine;
using System.Collections;

/// <summary>
/// �ėp�I�ȗ���State
/// </summary>
public class FallState : BaseState {

    public int name
    {
        get { return (int)GENERICSTATENAME.Fall; }
    }

    private FrameCounter framecounter;
    private float scale = 0.95F;
	public FallState(BaseCharacter parent):base(parent)
	{
		framecounter = new FrameCounter(60);
	}
	
	public override int Update()
	{
		var state = FrameUpdate();
		
		Falling();
		
		return (int)state;
	}
	
	private void Falling()
	{
        Vector3 fall = stateParent.transform.localScale;
		fall.x *= scale;fall.y *= scale;
	  	stateParent.transform.localScale = fall;
        stateParent.collider.enabled = false;
	}

    /// <summary>
    /// ��Ԃ��I�������ꍇ�Anull��Ԃ�
    /// </summary>
    /// <returns></returns>
    private GENERICSTATENAME FrameUpdate()
    {
        framecounter.Update();
        return framecounter.IsCall ? GENERICSTATENAME.Changeless : GENERICSTATENAME.Fall;
    }
}
