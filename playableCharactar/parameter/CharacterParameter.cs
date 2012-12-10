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
	
	public Charge charge
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
	private const float MAX =100F;
	
	public float quantity { private set; get; }
	public float speed { set; get; }
	public bool isMax { get { return quantity >= MAX; }}
	public void Charging()
	{
		quantity += speed;
		if(quantity > MAX)quantity = MAX;
	}
	
	public void Clear()
	{
		quantity = 0;
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

public class FrameCounter
{
	public int count
	{
		get;
		private set;
	}
	public bool IsCall
	{
		get
		{
		   return count % callTiming == 0;
		}
	}
	private int callTiming;
	
	public FrameCounter(int interval)
	{
		callTiming = interval;
	}
	
	public void Update()
	{
		count++;
	}
}

public class Damage
{
	public int hitStop
	{
		get;
		set;
	}
	public float quantity
	{
		get;
		set;
	}
	public int direction
	{
		get;
		set;
	}
}