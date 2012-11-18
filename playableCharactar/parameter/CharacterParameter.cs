using UnityEngine;
using System.Collections;

public class CharacterParameter
{
	private Power power;
	private Deffence deffence;
	private Weight weight;
	private Stamina stamina;
	private Charge charge;
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
	float quantity;
}

public class Deffence
{
	float quantity;
}

public class Power
{
	float power;
}