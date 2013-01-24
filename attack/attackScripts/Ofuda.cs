using UnityEngine;
using System.Collections;

public class Ofuda : BaseAttack {


    void Awake()
    {
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(3, false)
        };
        baseParameter = new BaseParameter(sprite);
    }
	// Use this for initialization
	void Start () {

        state = new MoveState(this);
        var angle = sprite.gameObject.transform.localEulerAngles;
        angle = new Vector3(0, 0, baseParameter.moveParameter.direction - 90);
        sprite.gameObject.transform.localEulerAngles = angle;

	}

	// Update is called once per frame
	void Update () {
        state.Update();

        CheckOutLine();
	}

    private void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }
}
