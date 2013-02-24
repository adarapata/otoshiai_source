using UnityEngine;
using System.Collections;

public partial class Yugi : Character {

    protected override IState CreateSkillState()
    {
        return new YugiSkillState(this);
    }
    protected override IState CreateChargeSkillState()
    {
        return new YugiChargeSkillState(this);
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
        if (IsCheckSameTeam(other)) return;
    }

    void OnTriggerStay(Collider other)
    {
        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy is BaseBox) CheckColliedingBox(enemy as BaseBox);
    }
}
