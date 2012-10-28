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
		private get;
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
		private get;
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
	public Vector3 ConvertToPolar(int direction, float speed)
	{
		Vector3 val = new Vector3(Mathf.Cos(direction * Mathf.Deg2Rad) * speed, Mathf.Sin(direction * Mathf.Deg2Rad) * speed, 0f);
		return val;
	}

	public Vector3 ConvertToPolar()
	{
		return ConvertToPolar(direction, speed);
	}
}

