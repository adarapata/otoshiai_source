using UnityEngine;
using System.Collections;

/// <summary>
/// �X�^�~�i�Q�[�W�������N���X
/// </summary>
public class StaminaGaugeController : MonoBehaviour {
    /// <summary>
    /// �X�^�~�i�P�ӂ�̃o�[�̃T�C�Y
    /// </summary>
    private const float ONE_SIZE = 1.25F;

    /// <summary>
    /// �X�^�~�i�l
    /// </summary>
    public Stamina stamina
    {
        get;
        set;
    }
    /// <summary>
    /// �摜
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

        //localPosition,Rotation,Scale��ύX���Ă�
        //atlas��pivot��ύX����܂ŉ�ʂɔ��f����Ȃ����ۂ��̂�
        //��U�ς��āA�܂�Bottum�ɖ߂��Ĕ��f�����Ă���
        sprite.pivot = UIWidget.Pivot.BottomLeft;
        sprite.pivot = UIWidget.Pivot.Bottom;
    }
}
