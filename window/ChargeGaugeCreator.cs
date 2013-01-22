using UnityEngine;
using System.Collections;

/// <summary>
/// �`���[�W�Q�[�W�Ǘ��N���X
/// </summary>
public class ChargeGaugeCreator : MonoBehaviour {

    /// <summary>
    /// ���[�^�[
    /// </summary>
    public ChargeGaugeMeter[] meters = new ChargeGaugeMeter[60];
   
    /// <summary>
    /// �Ώۂ̃L����
    /// </summary>
    public Character parent
    {
        get;
        set;
    }
    /// <summary>
    /// �Ώۂ̃`���[�W�Q�[�W
    /// </summary>
    public Charge charge
    {
        get;
        set;
    }
    /// <summary>
    /// ���������������̂ɕK�v�ȃ`���[�W��
    /// </summary>
    private const float COUNT = 1.6F;
    /// <summary>
    /// ���݂̃������ԍ�
    /// </summary>
    private int nowNumber;
	// Use this for initialization
	void Start () {
        if (parent == null) { Destroy(gameObject); return; }
	}
	
	// Update is called once per frame
	void Update () {

        if (!charge.isCharging) { Delete(); return; }

        //���W�͏�ɃL�����Ɠ���
        transform.localPosition = parent.transform.localPosition;

        if (nowNumber >= meters.Length) return;

        CheckMeter();
        if (nowNumber >= meters.Length) EffectMaxCharge();
	}

    private void Delete()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// �_�ŏ������Ăяo��
    /// </summary>
    private void EffectMaxCharge()
    {
        foreach (var m in meters)
        {
            m.StartBlink();
        }
    }

    /// <summary>
    /// �`���[�W�ʂ����ă������𑝂₷
    /// </summary>
    private void CheckMeter()
    {
        if (charge.quantity > nowNumber * COUNT)
        {
            meters[nowNumber].meter = true;
            nowNumber++;
        }
    }
}
