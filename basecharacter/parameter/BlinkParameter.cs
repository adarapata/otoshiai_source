using UnityEngine;
using System.Collections;

public class BlinkParameter {
    public UISprite targetSprite
    {
        get;
        private set;
    }
    public bool flag
    {
        get;
        private set;
    }
	private int blinkTime;
    
    public BlinkParameter(UISprite sprite)
    {
        targetSprite = sprite;
    }

    public void Start(int setTime, bool isOverride)
    {
        if (flag && !isOverride) return;
        flag = true;
        blinkTime = setTime;
    }

    public void Update()
    {
        if (blinkTime <= 0) 
        {
            targetSprite.enabled = true;
            flag = false;
            return;
        }

        targetSprite.enabled = !targetSprite.enabled;

    }
}

