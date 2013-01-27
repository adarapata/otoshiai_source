using UnityEngine;
using System.Collections;

public static class Extensions  {

    static public float Ccw(this Vector2 from,Vector2 to)
    {
        return from.x * to.y - from.y * to.x;
    }
}
