using UnityEngine;
using System.Collections;

/// <summary>
/// �`�[���F�̒萔
/// </summary>
public class TeamColor
{
    public const string RED = "red";
    public const string BLUE = "blue";
    public const string YELLOW = "yellow";
    public const string GREEN = "green";
    public const string NONE = "none";
    static private string[] layer_names;

    /// <summary>
    /// ���C���[�ԍ�����`�[���J���[��SpriteName���擾
    /// </summary>
    /// <param name="layer"></param>
    /// <returns></returns>
    static public string GetLayerName(int layer)
    {
        if (layer_names == null) { layer_names = new string[] { RED, BLUE, YELLOW, GREEN, NONE }; }
        return layer_names[layer];
    }
}

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
        if (character == null) Destroy(gameObject);
	}

    /// <summary>
    /// �����ݒ�
    /// </summary>
    public void Init(Character chara, int number)
    {
        character = chara;
        //�I�u�W�F�N�g�̃^�O����L�����N�^�[�̃A�C�R����ݒ�
        icon.spriteName = character.tag;

        //�L�����̃��C���[�ԍ�����`�[���J���[�����擾
        teamColor.spriteName = TeamColor.GetLayerName(character.gameObject.layer);
    }
}