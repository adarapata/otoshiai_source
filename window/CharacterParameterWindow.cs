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
    /// �����ݒ�
    /// </summary>
    private void Init()
    {
        //�I�u�W�F�N�g������L�����N�^�[�̃A�C�R����ݒ�
        icon.spriteName = character.name;

    }
}
