using UnityEngine;
using System.Collections;

public class PolarCoordinates {

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
	
	public Vector3 ConvertToPolar(int direction, float speed)
	{
		Vector3 val = new Vector3(Mathf.Cos(direction) * speed, Mathf.Sin(direction) * speed, 0f);
		return val;
	}

	public Vector3 ConvertToPolar()
	{
		return ConvertToPolar(direction, speed);
	}
}

