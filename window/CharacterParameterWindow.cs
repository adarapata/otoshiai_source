using UnityEngine;
using System.Collections;

public class CharacterParameterWindow : MonoBehaviour {

    public UISprite teamColor, icon;

    public Character character
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

    /// <summary>
    /// 初期設定
    /// </summary>
    private void Init()
    {
        //オブジェクト名からキャラクターのアイコンを設定
        icon.spriteName = character.name;

    }
}
