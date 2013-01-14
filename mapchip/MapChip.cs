using UnityEngine;
using System.Collections;

/// <summary>
/// 基本的なマップチップクラス
/// </summary>
public class MapChip : BaseCharacter
{

    #region GUIから設定させるためのパラメータ
    public float hp;
    public bool isAutoDeduct;
    public float autoDeduct;
    #endregion

    private MapChipParameter parameter
    {
        get;
        set;
    }
    private MAPCHIPSTATE mapchipState;

    public bool isLive
    {
        get { return parameter.hp.isLive; }
    }

    /// <summary>
    /// マップチップ座標の設定
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetMapPosition(int x, int y)
    {
        baseParameter = new BaseParameter();
        baseParameter.mapPosition = new MapPosition(x, y);

        var screenPos = baseParameter.mapPosition.GetScreenPositionByMapPosition();
        transform.localPosition = new Vector3(screenPos.x,
                                                screenPos.y,
                                                  1F);

    }

    /// <summary>
    /// 基本パラメータの初期化
    /// </summary>
    protected void InitParameter()
    {
         parameter = new MapChipParameter(this,
            isAutoDeduct ? new MapChipHP(hp, autoDeduct) : new MapChipHP(hp)
        );

        animation = new MapChipAnimationController(sprite);
    }
	// Use this for initialization
	void Start () {
        InitParameter();
	}
	
	// Update is called once per frame
	void Update () {
        parameter.Update();
	}

    public void SetDamage(float damage)
    {
        parameter.hp.Damage(damage);
    }
}