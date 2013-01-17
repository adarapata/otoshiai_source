using UnityEngine;
using System.Collections;

public class Ofuda : BaseAttack {


    void Awake()
    {
        baseParameter = new BaseParameter();
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(3, false)
        };
    }
	// Use this for initialization
	void Start () {
        state = new MoveState(this);
	}

	// Update is called once per frame
	void Update () {
        state.Update();
	}

    private void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }
}
