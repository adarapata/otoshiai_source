using UnityEngine;
using System.Collections;

/// <summary>
/// 汎用的なstateの番号
/// </summary>
enum GENERICSTATENAME : int
{
    Changeless = 1000,
    Move,
    Fall
}

enum GENERICATTACKSTATENAME : int
{
    Homing = 0,
    Changeless = GENERICSTATENAME.Changeless
}