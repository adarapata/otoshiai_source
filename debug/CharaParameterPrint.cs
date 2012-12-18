using UnityEngine;
using System.Collections;

public class CharaParameterPrint : MonoBehaviour {
	
	public UILabel label;
	public Character chara;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        label.text = chara.parameter.stamina.quantity.ToString("f1") + "\n"
            + chara.animation.sprite.spriteName + "\n"
            + chara.parameter.attackCharge.quantity.ToString("f1") + "\n"
            + chara.parameter.skillCharge.quantity.ToString("f1") + "\n";

        if (Input.GetKeyDown(KeyCode.Q)) { chara.ChangeFallState(); }
        if (Input.GetKeyDown(KeyCode.W)) {
            Damage dmg = new Damage(30, false, 10, (int)Stick.Right, false);
            chara.ChangeHitState(dmg); 
        }
	}
}
