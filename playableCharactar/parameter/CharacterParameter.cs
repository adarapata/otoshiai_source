using UnityEngine;
using System.Collections;

public class CharacterParameter
{
	public Power power
	{
		get;
		set;
	}
	public Diffence diffence
	{
		get;
		set;
	}
	
	public Weight weight
	{
		get;
		set;
	}
	
	public Stamina stamina
	{
		get;
		set;
	}
}

public class Stamina
{
	const int MAX = 100;
	
	private float m_quantity;
	
 	public float quantity
	{
		get{ return m_quantity; }
		set
		{
			m_quantity = value;
			if(m_quantity > MAX)m_quantity = MAX;
			else if(m_quantity < 0)m_quantity = 0;
		}
	}
	
	public float recoveryRate
	{
		get;
		set;
	}
	
	public void Recovery(float rate)
	{
		quantity += rate;
	}
	
	public void Recovery()
	{
		Recovery(recoveryRate);
	}
}

public class Charge
{
	public const float MAX =100F;
	
	public float quantity
	{
		get;
		set;
	}
	public float speed
	{
		get;
		set;
	}
}

public class Weight
{
	public const float HEAVY = 65F;
	public const float MIDDLE = 50F;
	public const float LIGHT = 35F;
	
	public float quantity
	{
		get;
		set;
	}
	
	static public Vector3 CalculateVelocityByWeight(MoveParameter param, Weight weight)
	{
		return param.velocity * (Weight.MIDDLE / weight.quantity);
	}
}

public class Diffence
{
	public float quantity
	{
		get;
		set;
	}
}

public class Power
{
	public float quantity
	{
		get;
		set;
	}
}