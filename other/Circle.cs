using UnityEngine;
using System.Collections;

public class Circle : BaseCharacter {

    public Character parent;
    public TweenRotation rotation;
    public TweenScale scaling;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        sprite.pivot = UIWidget.Pivot.Bottom;
        sprite.pivot = UIWidget.Pivot.Center;

        if(parent.state.name != (int)Character.STATENAME.ChargeSkill)
        {
            Destroy(gameObject);
        }
	}
}
