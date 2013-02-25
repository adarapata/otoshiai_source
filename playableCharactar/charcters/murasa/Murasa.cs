using UnityEngine;
using System.Collections;

public partial class Murasa : Character
{
    public GameObject ikari;

    protected override IState CreateSkillState()
    {
        return new MurasaSkillState(this);
    }
    protected override IState CreateChargeSkillState()
    {
        if (ikari != null) { return new CharacterStayState(this, parent.gamepad); }
        return new MurasaChargeSkillState(this);
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