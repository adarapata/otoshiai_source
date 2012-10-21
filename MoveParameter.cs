using UnityEngine;
using System.Collections;

public class MoveParameter : MonoBehaviour
{
	private PolarCoordinates m_polar;

	public Vector3 velocity
	{
		get;
		private set;
	}
	
	public float speed
	{
		set 
		{ 
			m_polar.speed = value; 
			Caluclate();
		}
	}
	
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

	private void Caluclate()
	{
		velocity = m_polar.ConvertToPolar();
	}
}

