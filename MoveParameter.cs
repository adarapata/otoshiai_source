using UnityEngine;
using System.Collections;

public class MoveParameter : MonoBehaviour
{
	private Poler m_poler;

	public Vector3 velocity
	{
		get;
		private set;
	}
	
	public float speed
	{
		set 
		{ 
			m_poler.speed = value; 
			Caluclate();
		}
	}
	
	public int direction
	{
		set 
		{ 
			m_poler.direction = value;
			Caluclate();
		}
	}

	public MoveParameter(Poler poler)
	{
		m_poler = poler;
		Caluclate();
	}

	private void Caluclate()
	{
		velocity = m_poler.ConvertToPoler();
	}
}

