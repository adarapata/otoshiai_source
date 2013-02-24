using UnityEngine;
using System.Collections;

/// <summary>
/// 汎用的な落下State
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
    /// 状態が終了した場合、nullを返す
    /// </summary>
    /// <returns></returns>
    private GENERICSTATENAME FrameUpdate()
    {
        framecounter.Update();
        return framecounter.IsCall ? GENERICSTATENAME.Changeless : GENERICSTATENAME.Fall;
    }
}
