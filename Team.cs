using UnityEngine;
using System.Collections;

public enum TEAMCODE
{
    red = 0,
    blue,
    yellow,
    green,
    none
}

public class Team {
    public TEAMCODE name
    {
        get;
        set;
    }

    public Team(TEAMCODE code)
    {
        name = code;
    }
}
