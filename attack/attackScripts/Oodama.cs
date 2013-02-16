using UnityEngine;
using System.Collections;

public class Oodama : BaseAttack {

    void Awake()
    {
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(3, false)
        };
        baseParameter = new BaseParameter(sprite);
    }
    // Use this for initialization
    void Start()
    {

        Init();

        state = new MoveState(this);
        PolarCoordinates.RotateAngles(sprite.gameObject.transform, baseParameter.moveParameter.direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameParameter.instance.Pause) return;

        state.Update();

        CheckOutLine();
    }

    private void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }
}
