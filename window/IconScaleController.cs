using UnityEngine;
using System.Collections;

public class IconScaleController : MonoBehaviour
{

    /// <summary>
    /// �̏d
    /// </summary>
    public Weight weight
    {
        get;
        set;
    }
    /// <summary>
    /// �摜
    /// </summary>
    private UISprite sprite;
    private float defaultScaleX;

    void Start()
    {

    }

    public void SetDefault()
    {
        sprite = GetComponent<UISprite>();
        transform.localScale = new Vector2(sprite.sprite.inner.width, sprite.sprite.inner.height);
        defaultScaleX = transform.localScale.x;
    }

    void Update()
    {
        if (MainGameParameter.instance.Pause) return;

        var scale = transform.localScale;
        scale.x = defaultScaleX * (weight.quantity / weight.defaultWeight);
        transform.localScale = scale;

        //localPosition,Rotation,Scale��ύX���Ă�
        //atlas��pivot��ύX����܂ŉ�ʂɔ��f����Ȃ����ۂ��̂�
        //��U�ς��āA�܂�Bottum�ɖ߂��Ĕ��f�����Ă���
        sprite.pivot = UIWidget.Pivot.BottomLeft;
        sprite.pivot = UIWidget.Pivot.Center;
    }
}
