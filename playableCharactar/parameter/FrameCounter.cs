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
    /// カウントを初期化する
    /// </summary>
    public void Clear()
    {
        count = 0;
    }

    /// <summary>
    /// 呼び出すタイミングを再設定する。カウントも初期化される
    /// </summary>
    /// <param name="timing"></param>
    public void ChangeCallTiming(int newTiming)
    {
        callTiming = newTiming;
        Clear();
    }
    
}