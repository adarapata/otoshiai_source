using UnityEngine;
using System.Collections;

public class NormalBlow : BaseAttack
{


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
        baseParameter.moveParameter = new MoveParameter(parent.frontDirection, 10F);
    }

    void Update()
    {
        if (MainGameParameter.instance.Pause) return;
        transform.localPosition = parent.transform.localPosition + baseParameter.moveParameter.velocity;
        if (syncCounter.IsCall || parent.state.name != (int)Character.STATENAME.Blow) SelfDestroy();
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other.gameObject);
    }
}
