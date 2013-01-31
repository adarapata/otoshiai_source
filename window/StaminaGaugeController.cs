using UnityEngine;
using System.Collections;

/// <summary>
/// スタミナゲージを扱うクラス
/// </summary>
public class StaminaGaugeController : MonoBehaviour {
    /// <summary>
    /// スタミナ１辺りのバーのサイズ
    /// </summary>
    private const float ONE_SIZE = 1.25F;

    /// <summary>
    /// スタミナ値
    /// </summary>
    public Stamina stamina
    {
        get;
        set;
    }
    /// <summary>
    /// 画像
    /// </summary>
    public UISprite sprite;

    void start()
    {

    }

    void Update()
    {
        if (MainGameParameter.instance.Pause) return;

        var scale = sprite.gameObject.transform.localScale;
        scale.y = ONE_SIZE * stamina.quantity;

        sprite.gameObject.transform.localScale = scale;

        //localPosition,Rotation,Scaleを変更しても
        //atlasのpivotを変更するまで画面に反映されないっぽいので
        //一旦変えて、またBottumに戻して反映させている
        sprite.pivot = UIWidget.Pivot.BottomLeft;
        sprite.pivot = UIWidget.Pivot.Bottom;
    }
}
