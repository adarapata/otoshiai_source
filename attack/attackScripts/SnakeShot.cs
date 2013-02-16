using UnityEngine;
using System.Collections;

/// <summary>
/// ˆê‰ñ‚¾‚¯‹È‚ª‚é
/// </summary>
public class SnakeShot : BaseAttack
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

        attackParameter.damage = new Damage(30, false, 10, parent.frontDirection, false);
        baseParameter.moveParameter = new MoveParameter(parent.frontDirection, 5F);


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

    private void Search()
    {
 
    }
}
