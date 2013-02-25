using UnityEngine;
using System.Collections;

public class Tenko : Character {

    protected override IState CreateSkillState()
    {
        return null;
    }
    protected override IState CreateChargeSkillState()
    {
        return null;
    }

    void Awake()
    {
        InitCharacterParameter();
    }
    // Use this for initialization
    void Start()
    {
        InitData();
    }

    // Update is called once per frame
    void Update()
    {
        ScriptUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {
        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy is BaseBox) CheckColliedingBox(enemy as BaseBox);
    }
}
