using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationParameter
{
    public int frame;
    public string pattern;

    public string spriteName
    {
        get { return pattern + frame.ToString(); }
    }

    private List<string> nameList;

    public AnimationParameter(List<string> animationNameList)
    {
        nameList = animationNameList;
    }

    public string NextFrame(bool isLoop)
    {
        string nextframe = pattern + (frame + 1).ToString();
        if (!nameList.Contains(nextframe))
        {
            frame = isLoop ? 0 : frame;
            return spriteName;
        }
        frame++;
        return nextframe;
    }

    public string ChangePattern(string newPattern)
    {
        if (!nameList.Contains(newPattern + "0")) return "";

        frame = 0;
        pattern = newPattern;
        return spriteName;
    }
}
