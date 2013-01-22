using UnityEngine;
using System.Collections;


/// <summary>
/// チャージゲージのメモリ１つ分
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
    /// 画面に表示するかどうかの設定
    /// </summary>
    public bool meter
    {
        get { return white.enabled; }
        set { white.enabled = value; }
    }

    /// <summary>
    /// 点滅開始。実質無制限
    /// </summary>
    public void StartBlink()
    {
        blink.Start(INFINITY, false);
    }
}
