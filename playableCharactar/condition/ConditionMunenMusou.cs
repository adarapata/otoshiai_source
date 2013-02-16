using UnityEngine;
using System.Collections;

public class ConditionMunenMusou : BaseCondition {

    private Damage totalDamage;
    public ConditionMunenMusou(Character parent)
        : base(parent)
    {
        totalDamage = new Damage(60, false, 0, Random.Range(0, 360), true);
        framecounter = new FrameCounter(600);
    }

    public override BaseCondition Update()
    {
        base.Update();

        if (framecounter.IsCall)
        {
            parent.ChangeHitState(totalDamage);
            return null;
        }
        return this;
    }

    public void AddDamage(Damage d)
    {
        totalDamage.damageParameter.damage += d.damageParameter.damage;
    }
}
