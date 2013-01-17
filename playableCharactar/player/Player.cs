using UnityEngine;
using System.Collections;

public class Player : IObjectOperator
{
    public IGamePad gamepad
    {
        get;
        set;
    }

    public BaseCharacter operationObject
    {
        get
        {
            return character.GetComponent<Character>();
        }
    }


    public GameObject character
    {
        get;
        set;
    }

    public int number
    {
        get;
        set;
    }

    public Team team
    {
        get;
        set;
    }

    public Player(int num)
    {
        number = num;
    }
    public void Update()
    { }
}