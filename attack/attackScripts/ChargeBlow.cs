using UnityEngine;
using System.Collections;

public class ChargeBlow : BaseAttack {

    public FrameCounter syncCounter
    {
        get;
        set;
    }

    /*
     * �L�����̍��W�ɏd�˂銴����
     */
    void Awake()
    {
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(5, true)
        };
        baseParameter = new BaseParameter(null);
    }

    void Start()
    {
        Init();
        attackParameter.damage = new Damage(20, false, parent.parameter.power.quantity*2, parent.frontDirection, false);
        baseParameter.moveParameter = new MoveParameter(parent.frontDirection, 5F);
    }

    void Update()
    {
        transform.localPosition = parent.transform.localPosition + baseParameter.moveParameter.velocity;
        if (syncCounter.IsCall || !(parent.state is CharacterChargeBlowState)) SelfDestroy();
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }
}