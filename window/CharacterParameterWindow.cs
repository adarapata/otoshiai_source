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
    static public string GetLayerName(TEAMCODE teamCode)
    {
        if (layer_names == null) { layer_names = new string[] { RED, BLUE, YELLOW, GREEN, NONE }; }
        return layer_names[(int)teamCode];
    }
}

public class CharacterParameterWindow : MonoBehaviour {

    public GameObject chargeMeter, stamina;
    public UISprite teamColor, icon;
    private StaminaGaugeController staminaGauge;

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

        staminaGauge.Update();
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
        teamColor.spriteName = TeamColor.GetLayerName(character.parent.team.name);

        //�L�����̃p�����[�^�E�B���h�E�Ɏ���������
        chara.parameterWindow = this;

        staminaGauge = new StaminaGaugeController(stamina, chara.parameter.stamina);
    }

    /// <summary>
    /// �`���[�W���[�^�[���쐬
    /// </summary>
    public void CreateChargeParameterWindow(Charge targetCharge)
    {
        var chargeW = (Instantiate(chargeMeter) as GameObject).GetComponent<ChargeGaugeCreator>();
        chargeW.parent = character;
        chargeW.transform.parent = transform.parent;
        chargeW.transform.localPosition = character.transform.localPosition;
        chargeW.transform.localScale = Vector3.one;
        chargeW.charge = targetCharge;
    }
}
