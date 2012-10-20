using UnityEngine;
using System.Collections;

public class BaseCharactar : MonoBehaviour {
	public IState state {
		get;
		set;
	}
	
	public BaseParameter baseParameter {
		get;
		set;
	}
	
	// Use this for initialization
	void Start () {
		state = new BaseState(this);
	}
	
	// Update is called once per frame
	void Update () {
		state.Update();
	}
}

public class MoveParameter {

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

public class Poler {

	public float speed
	{
		private get;
		set;
	}
	public int direction
	{
		private get;
		set;
	}

	public Poler(int direction, float speed)
	{
		this.direction = direction;
		this.speed = speed;
	}

	public Vector3 ConvertToPoler(int direction, float speed)
	{
		Vector3 val = new Vector3(Mathf.Cos(direction) * speed, Mathf.Sin(direction) * speed, 0f);
		return val;
	}

	public Vector3 ConvertToPoler()
	{
		return ConvertToPoler(direction, speed);
	}
}
public class BlinkParameter {
	private int blinkTime;
}

public class BaseParameter {	
	public BlinkParameter blinkParameter {
		get;
		set;
	}

	public MoveParameter moveParameter {
		get;
		set;
	}
}