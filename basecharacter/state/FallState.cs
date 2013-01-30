using UnityEngine;
using System.Collections;

/// <summary>
/// �ėp�I�ȗ���State
/// </summary>
public class FallState : BaseState {
    
    private FrameCounter framecounter;
    private float scale = 0.95F;
	public FallState(BaseCharacter parent):base(parent)
	{
		framecounter = new FrameCounter(60);
	}
	
	public override System.Type Update()
	{
		var state = FrameUpdate();
		
		Falling();
		
		return state;
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
    private System.Type FrameUpdate()
    {
        framecounter.Update();
        return framecounter.IsCall ? typeof(BaseState) : null;
    }
}
