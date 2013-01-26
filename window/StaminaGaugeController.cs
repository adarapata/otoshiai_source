using UnityEngine;
using System.Collections;

/// <summary>
/// スタミナゲージを扱うクラス
/// </summary>
public class StaminaGaugeController {
    /// <summary>
    /// スタミナ１辺りのバーのサイズ
    /// </summary>
    private const float ONE_SIZE = 1.25F;
    /// <summary>
    /// ターゲットのゲージ
    /// </summary>
    private GameObject target
    {
        get;
        set;
    }
    /// <summary>
    /// スタミナ値
    /// </summary>
    private Stamina stamina;
    /// <summary>
    /// 画像
    /// </summary>
    private UISprite sprite;

    public StaminaGaugeController(GameObject targetBar, Stamina targetStamina)
    {
        target = targetBar;
        stamina = targetStamina;
        sprite = target.GetComponent<UISprite>();
    }

    public void Update()
    {
        var scale = target.transform.localScale;
        scale.y = ONE_SIZE * stamina.quantity;

        target.transform.localScale = scale;

        //localPosition,Rotation,Scaleを変更しても
        //atlasのpivotを変更するまで画面に反映されないっぽいので
        //一旦変えて、またBottumに戻して反映させている
        sprite.pivot = UIWidget.Pivot.BottomLeft;
        sprite.pivot = UIWidget.Pivot.Bottom;
    }
}
