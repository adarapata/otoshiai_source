using UnityEngine;
using System.Collections;

public class NormalBlow : BaseAttack {


    public FrameCounter syncCounter
    {
        get;
        set;
    }

    /*
     * ÉLÉÉÉâÇÃç¿ïWÇ…èdÇÀÇÈä¥Ç∂Ç≈
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
        if (syncCounter.IsCall || !(parent.state is CharacterBlowState)) SelfDestroy();
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }
}
