using UnityEngine;
using System.Collections;

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

