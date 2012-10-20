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

	public MoveParameter(Poler poler)
	{
		m_poler = poler;
	}

	public void Caluclate()
	{
		Caluclate(m_poler);
	}

	public void Caluclate(Poler poler)
	{
		velocity = poler.ConvertToPoler();
	}
}

