using UnityEngine;
using System.Collections;

public class IconScaleController:MonoBehaviour {

    /// <summary>
    /// スタミナ値
    /// </summary>
    public Weight weight
    {
        get;
        set;
    }
    /// <summary>
    /// 画像
    /// </summary>
    private UISprite sprite;
    private float defaultScaleX;

    void Start()
    {
        sprite = GetComponent<UISprite>();
        defaultScaleX = transform.localScale.x;
    }

    void Update()
    {
        if (MainGameParameter.instance.Pause) return;

        var scale = transform.localScale;
        scale.x = defaultScaleX * (weight.quantity / weight.defaultWeight);
        transform.localScale = scale;

        //localPosition,Rotation,Scaleを変更しても
        //atlasのpivotを変更するまで画面に反映されないっぽいので
        //一旦変えて、またBottumに戻して反映させている
        sprite.pivot = UIWidget.Pivot.BottomLeft;
        sprite.pivot = UIWidget.Pivot.Center;
    }
}
