using UnityEngine;
using System.Collections;

public class BaseItem : BaseCharacter {

    protected FrameCounter framecounter
    {
        get;
        set;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    virtual protected void Init()
    {
        framecounter = new FrameCounter(600);
        baseParameter = new BaseParameter(sprite);
    }
    virtual protected void ScriptUpdate()
    {
        framecounter.Update();

        if (framecounter.count == 420)
        {
            baseParameter.blinkParameter.Start(180, false);
        }

        if (framecounter.IsCall) { SelfDestroy(); }
    }
    /// <summary>
    /// Œø‰Ê”­“®
    /// </summary>
    virtual public void EffectMotion(Character target)
    { 
    }

    virtual public void ColliedCheck(Collider other)
    {
        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy is Character)
        {
            EffectMotion(enemy as Character);
            SelfDestroy();
        }
    }
}
