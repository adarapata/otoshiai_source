using UnityEngine;
using System.Collections;


/// <summary>
/// �`���[�W�Q�[�W�̃������P��
/// </summary>
public class ChargeGaugeMeter : MonoBehaviour {

    private const int INFINITY = int.MaxValue;
    public UISprite white, black;
    private BlinkParameter blink;
	// Use this for initialization
	void Start () {
        meter = false;
        //black.color = new Color(1, 1, 1, 0.6F);
        blink = new BlinkParameter(white);
	}
	
	// Update is called once per frame
    void Update()
    {
        if (blink.flag) blink.Update();
    }

    /// <summary>
    /// ��ʂɕ\�����邩�ǂ����̐ݒ�
    /// </summary>
    public bool meter
    {
        get { return white.enabled && black.enabled; }
        set { white.enabled = black.enabled = value; }
    }

    /// <summary>
    /// �_�ŊJ�n�B����������
    /// </summary>
    public void StartBlink()
    {
        blink.Start(INFINITY, false);
    }
}
