using UnityEngine;
using System.Collections;

/// <summary>
/// BaseCharactarが持つ基本パラメータ
/// </summary>
public class BaseParameter {
	/// <summary>
	/// 点滅処理用パラメータ
	/// get; set;
	/// </summary>
	/// <value>
	/// The blink parameter.
	/// </value>
	public BlinkParameter blinkParameter {
		get;
		set;
	}
	
	/// <summary>
	/// 移動処理用パラメータ
	/// get; set;
	/// </summary>
	/// <value>
	/// The move parameter.
	/// </value>
	public MoveParameter moveParameter {
		get;
		set;
	}

    public MapPosition mapPosition
    {
        get;
        set;
    }

    public Team team
    {
        get;
        set;
    }

	public BaseParameter(UISprite sprite)
	{
		blinkParameter = new BlinkParameter(sprite);
	}

    public void Update()
    {
        if (blinkParameter.flag) blinkParameter.Update();
    }
}
