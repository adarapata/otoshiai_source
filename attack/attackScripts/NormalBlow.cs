using UnityEngine;
using System.Collections;

public class NormalBlow : BaseAttack {


    public FrameCounter syncCounter
    {
        get;
        set;
    }

    /*
     * キャラの座標に重ねる感じで
     */
    void Awake()
    {
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(4, true)
        };
        baseParameter = new BaseParameter(null);
    }

    void Start()
    {
        Init();
        attackParameter.damage = new Damage(20, false, parent.parameter.power.quantity, parent.frontDirection, false);
        baseParameter.moveParameter = new MoveParameter(parent.frontDirection, 5F);
    }

    void Update()
    {
        transform.localPosition = parent.transform.localPosition + baseParameter.moveParameter.velocity;
        if (syncCounter.IsCall) SelfDestroy();
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }
}
