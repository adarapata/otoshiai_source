using UnityEngine;
using System.Collections;

public class CharacterParameter
{
    /// <summary>
    /// キャラの攻撃力
    /// </summary>
	public Power power
	{
		get;
		set;
	}
    /// <summary>
    /// 防御力
    /// </summary>
	public Diffence diffence
	{
		get;
		set;
	}
	/// <summary>
	/// 体重
	/// </summary>
	public Weight weight
	{
		get;
		set;
	}
	/// <summary>
	/// スタミナ
	/// </summary>
	public Stamina stamina
	{
		get;
		set;
	}

    /// <summary>
    /// 所有ダメージ
    /// </summary>
    public Damage damage
    {
        get;
        set;
    }

    public Charge attackCharge
    {
        get;
        set;
    }
    public Charge skillCharge
    {
        get;
        set;
    }

    /// <summary>
    /// 無敵状態パラメータ
    /// </summary>
    public Invincibly invincibly
    {
        get;
        set;
    }

    public void Update()
    {
        if (invincibly.flag) invincibly.Update();
    }
}

/// <summary>
/// 無敵判定を管理するクラス
/// </summary>
public class Invincibly
{
    /// <summary>
    /// ダメージを受けない状態かどうか
    /// </summary>
    public bool flag
    {
        get;
        private set;
    }

    /// <summary>
    /// 無敵状態の残時間(フレーム数)
    /// </summary>
    public int time
    {
        get;
        private set;
    }

    /// <summary>
    /// 無敵時間の設定
    /// </summary>
    /// <param name="setTime">無敵フレーム数</param>
    /// <param name="isOverride">すでに無敵状態の時に、時間を上書きするか</param>
    public void Start(int setTime, bool isOverride)
    {
        if (flag && !isOverride) return;
        flag = true;
        time = setTime;
    }

    public void Update()
    {
        flag = time-- > 0;
    }
}