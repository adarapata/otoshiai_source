using UnityEngine;
using System.Collections;


/// <summary>
/// �`���[�W�Q�[�W�̃������P��
/// </summary>
public class ChargeGaugeMeter : MonoBehaviour {

    private const int INFINITY = int.MaxValue;
    public UISprite white;
    private BlinkParameter blink;
	// Use this for initialization
	void Start () {
        blink = new BlinkParameter(white);
	}
	
	// Update is called once per frame
	void Update () {
        if (blink.flag) blink.Update();
	}

    /// <summary>
    /// ��ʂɕ\�����邩�ǂ����̐ݒ�
    /// </summary>
    public bool meter
    {
        get { return white.enabled; }
        set { white.enabled = value; }
    }

    /// <summary>
    /// �_�ŊJ�n�B����������
    /// </summary>
    public void StartBlink()
    {
        blink.Start(INFINITY, false);
    }
}
