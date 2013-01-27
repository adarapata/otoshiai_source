using UnityEngine;
using System.Collections;

public class FrameCounter
{
    public int count
    {
        get;
        private set;
    }
    public bool IsCall
    {
        get
        {
            return count % callTiming == 0;
        }
    }
    private int callTiming;

    public FrameCounter(int interval)
    {
        callTiming = interval;
    }

    public void Update()
    {
        count++;
    }

    /// <summary>
    /// ƒJƒEƒ“ƒg‚ğ‰Šú‰»‚·‚é
    /// </summary>
    public void Clear()
    {
        count = 0;
    }
}