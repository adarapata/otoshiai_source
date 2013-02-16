using UnityEngine;
using System.Collections;

public class Ikaring : BaseAttack {

    private int level = 0;
    const int MAX = 10;
    void Awake()
    {
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(5, false)
        };
        baseParameter = new BaseParameter(sprite);
    }
	// Use this for initialization
	void Start () {

        attackParameter.damage = new Damage(30, false, 20, parent.frontDirection, false);
        baseParameter.moveParameter = new MoveParameter(parent.frontDirection, 2F);

        state = new MoveState(this);
        PolarCoordinates.RotateAngles(sprite.gameObject.transform, baseParameter.moveParameter.direction);
	}

	// Update is called once per frame
	void Update () {
        if (MainGameParameter.instance.Pause) return;

        state.Update();

        CheckOutLine();
	}

    private void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }

    protected override void ColliedAttack(BaseAttack enemy)
    {
        level++;
        sprite.spriteName = "ikaring" + level;
        if (level >= MAX)
        {
            SelfDestroy();
        }
    }
}
