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
	float quantity;
	float recoveryRate;
}

public class Charge
{
	float quantity;
	float speed;
}

public class Weight
{
	public const float HEAVY = 65F;
	public const float MIDDLE = 50F;
	public const float LIGHT = 35F;
	public float quantity;
	
	static public Vector3 CalculateVelocityByWeight(MoveParameter param, Weight weight)
	{
		return param.velocity * (Weight.MIDDLE / weight.quantity);
	}
}

public class Diffence
{
	float quantity;
}

public class Power
{
	float quantity;
}