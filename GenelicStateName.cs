using UnityEngine;
using System.Collections;

/// <summary>
/// �ėp�I��state�̔ԍ�
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