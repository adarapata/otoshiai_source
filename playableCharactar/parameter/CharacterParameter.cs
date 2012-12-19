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
}