using UnityEngine;
using System.Collections;


/// <summary>
/// チャージゲージのメモリ１つ分
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
    /// 画面に表示するかどうかの設定
    /// </summary>
    public bool meter
    {
        get { return white.enabled && black.enabled; }
        set { white.enabled = black.enabled = value; }
    }

    /// <summary>
    /// 点滅開始。実質無制限
    /// </summary>
    public void StartBlink()
    {
        blink.Start(INFINITY, false);
    }
}
