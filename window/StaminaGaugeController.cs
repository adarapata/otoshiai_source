using UnityEngine;
using System.Collections;

/// <summary>
/// �X�^�~�i�Q�[�W�������N���X
/// </summary>
public class StaminaGaugeController {
    /// <summary>
    /// �X�^�~�i�P�ӂ�̃o�[�̃T�C�Y
    /// </summary>
    private const float ONE_SIZE = 1.25F;
    /// <summary>
    /// �^�[�Q�b�g�̃Q�[�W
    /// </summary>
    private GameObject target
    {
        get;
        set;
    }
    /// <summary>
    /// �X�^�~�i�l
    /// </summary>
    private Stamina stamina;
    /// <summary>
    /// �摜
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

        //localPosition,Rotation,Scale��ύX���Ă�
        //atlas��pivot��ύX����܂ŉ�ʂɔ��f����Ȃ����ۂ��̂�
        //��U�ς��āA�܂�Bottum�ɖ߂��Ĕ��f�����Ă���
        sprite.pivot = UIWidget.Pivot.BottomLeft;
        sprite.pivot = UIWidget.Pivot.Bottom;
    }
}
