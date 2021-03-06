using UnityEngine;
using System.Collections;

public class BlinkParameter {
    public UISprite targetSprite
    {
        get;
        private set;
    }
    FrameCounter counter;
    public bool flag
    {
        get;
        private set;
    }
	private int blinkTime;
    
    public BlinkParameter(UISprite sprite)
    {
        targetSprite = sprite;
        counter = new FrameCounter(3);
    }

    public void Start(int setTime, bool isOverride)
    {
        if (flag && !isOverride) return;
        flag = true;
        blinkTime = setTime;
    }

    public void Update()
    {
        counter.Update();

        if (blinkTime <= 0) 
        {
            targetSprite.enabled = true;
            flag = false;
            return;
        }
        //３フレームに一回消える
        targetSprite.enabled = !counter.IsCall;
        blinkTime--;
    }
}

