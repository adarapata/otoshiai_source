using UnityEngine;
using System.Collections;

/// <summary>
/// 極座標クラス
/// </summary>
public class PolarCoordinates {
	
	/// <summary>
	/// 速度係数
	/// private get; set;
	/// </summary>
	/// <value>
	/// The speed.
	/// </value>
	public float speed
	{
		get;
		set;
	}
	
	/// <summary>
	/// 向き情報
	/// private get; set;
	/// </summary>
	/// <value>
	/// The direction.
	/// </value>
	public int direction
	{
		get;
		set;
	}
	
	/// <summary>
	/// 向きと速度係数から移動ベクトルを返す
	/// </summary>
	/// <returns>
	/// The to polar.
	/// </returns>
	/// <param name='direction'>
	/// Direction.
	/// </param>
	/// <param name='speed'>
	/// Speed.
	/// </param>
	static public Vector3 ConvertToPolar(int direction, float speed)
	{
		Vector3 val = new Vector3(Mathf.Cos(direction * Mathf.Deg2Rad) * speed, Mathf.Sin(direction * Mathf.Deg2Rad) * speed, 0f);
		return val;
	}

	public Vector3 ConvertToPolar()
	{
		return ConvertToPolar(direction, speed);
	}

    /// <summary>
    /// 上を0度としてオブジェクトの回転を行う
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="rotate"></param>
    static public void RotateAngles(Transform transform, float rotate)
    {
        var angle = transform.localEulerAngles;
        angle = new Vector3(0, 0, rotate - 90);
        transform.localEulerAngles = angle;
    }
}

