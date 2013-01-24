using UnityEngine;
using System.Collections;

public class Reimu : Character {

    protected override IState CreateSkillState() 
    {
        return new ReimuSkillState(this); 
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

    private void OnTriggerStay(Collider other)
    {
        if (IsCheckSameTeam(other)) return;
    }
}
