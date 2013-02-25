using UnityEngine;
using System.Collections;

public class Shibuki : BaseAttack
{
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
        ColliedCheck(other.gameObject);
    }

    protected override void ColliedCharacter(Character enemy)
    {
        //スタミナを減らすぞ
        enemy.parameter.stamina.quantity -= 10F;
        base.ColliedCharacter(enemy);
    }
}
