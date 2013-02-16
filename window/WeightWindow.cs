using UnityEngine;
using System.Collections;

public class WeightWindow : MonoBehaviour {

    public Weight weight { get; set; }
    public UISprite sprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        sprite.spriteName = GetSpriteNameByWeight();   
	}

    private string GetSpriteNameByWeight()
    {
        if (weight.quantity <= Weight.LIGHT) { return "weight_light"; }
        if (weight.quantity <= Weight.MIDDLE) { return "weight_middle"; }
        return "weight_heavy";
    }
}
