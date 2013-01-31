using UnityEngine;
using System.Collections;

public class ItemDiet : BaseItem {

    // Use this for initialization
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ScriptUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }

    public override void EffectMotion(Character target)
    {
        target.parameter.weight.quantity -= 5;
        SoundManager.Play(SoundManager.item);
    }
}
