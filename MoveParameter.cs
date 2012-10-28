using UnityEngine;
using System.Collections;

/// <summary>
/// 移動処理の情報を持つクラス
/// </summary>
public class MoveParameter : MonoBehaviour
{
	/// <summary>
	/// 極座標データ
	/// </summary>
	private PolarCoordinates m_polar;
	
	/// <summary>
	/// 速度情報
	/// get;  private set;
	/// </summary>
	/// <value>
	/// The velocity.
	/// </value>
	public Vector3 velocity
	{
		get;
		private set;
	}
	
	/// <summary>
	/// 速度係数
	/// set;
	/// </summary>
	/// <value>
	/// The speed.
	/// </value>
	public float speed
	{
		set 
		{ 
			m_polar.speed = value; 
			Caluclate();
		}
	}
	
	/// <summary>
	/// 移動する向き
	/// set;
	/// </summary>
	/// <value>
	/// The direction.
	/// </value>
	public int direction
	{
		set 
		{ 
			m_polar.direction = value;
			Caluclate();
		}
	}

	public MoveParameter(PolarCoordinates polar)
	{
		m_polar = polar;
		Caluclate();
	}
	
	/// <summary>
	/// 速度情報の計算を行う;
	/// speed, directionのどちらかのsetterが呼ばれたときにフックされる
	/// </summary>
	private void Caluclate()
	{
		velocity = m_polar.ConvertToPolar();
	}
}

