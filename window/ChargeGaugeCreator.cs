using UnityEngine;
using System.Collections;

/// <summary>
/// チャージゲージ管理クラス
/// </summary>
public class ChargeGaugeCreator : MonoBehaviour {

    /// <summary>
    /// メーター
    /// </summary>
    public ChargeGaugeMeter[] meters = new ChargeGaugeMeter[60];
   
    /// <summary>
    /// 対象のキャラ
    /// </summary>
    public Character parent
    {
        get;
        set;
    }
    /// <summary>
    /// 対象のチャージゲージ
    /// </summary>
    public Charge charge
    {
        get;
        set;
    }
    /// <summary>
    /// メモリが一つ増えるのに必要なチャージ量
    /// </summary>
    private const float COUNT = 1.6F;
    /// <summary>
    /// 現在のメモリ番号
    /// </summary>
    private int nowNumber;
	// Use this for initialization
	void Start () {
        if (parent == null) { Destroy(gameObject); return; }
	}
	
	// Update is called once per frame
	void Update () {

        if (!charge.isCharging) { Delete(); return; }

        //座標は常にキャラと同じ
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
    /// 点滅処理を呼び出す
    /// </summary>
    private void EffectMaxCharge()
    {
        foreach (var m in meters)
        {
            m.StartBlink();
        }
    }

    /// <summary>
    /// チャージ量を見てメモリを増やす
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
