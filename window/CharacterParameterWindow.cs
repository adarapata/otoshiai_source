using UnityEngine;
using System.Collections;

/// <summary>
/// チーム色の定数
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
    /// レイヤー番号からチームカラーのSpriteNameを取得
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
    /// 初期設定
    /// </summary>
    public void Init(Character chara, int number)
    {
        character = chara;
        //オブジェクトのタグからキャラクターのアイコンを設定
        icon.spriteName = character.tag;

        //キャラのレイヤー番号からチームカラー名を取得
        teamColor.spriteName = TeamColor.GetLayerName(character.parent.team.name);

        //キャラのパラメータウィンドウに自分を入れる
        chara.parameterWindow = this;

        staminaGauge = new StaminaGaugeController(stamina, chara.parameter.stamina);
    }

    /// <summary>
    /// チャージメーターを作成
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
