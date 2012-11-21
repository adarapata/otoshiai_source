using UnityEngine;
using System.Collections;

public class CharaParameterPrint : MonoBehaviour {
	
	public UILabel label;
	public PlayableCharacter chara;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		label.text = chara.parameter.stamina.quantity.ToString("f1");
	}
}
