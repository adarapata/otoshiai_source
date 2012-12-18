using UnityEngine;
using System.Collections;

public class CharacterParameter
{
    /// <summary>
    /// �L�����̍U����
    /// </summary>
	public Power power
	{
		get;
		set;
	}
    /// <summary>
    /// �h���
    /// </summary>
	public Diffence diffence
	{
		get;
		set;
	}
	/// <summary>
	/// �̏d
	/// </summary>
	public Weight weight
	{
		get;
		set;
	}
	/// <summary>
	/// �X�^�~�i
	/// </summary>
	public Stamina stamina
	{
		get;
		set;
	}

    /// <summary>
    /// ���L�_���[�W
    /// </summary>
    public Damage damage
    {
        get;
        set;
    }

    public Charge attackCharge
    {
        get;
        set;
    }
    public Charge skillCharge
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
	/// <summary>
	/// �X�^�~�i��
	/// </summary>
	/// <param name="rate"></param>
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
	public float speed { private set;  get; }
	public bool isMax { get { return quantity >= MAX; }}

    public Charge(float chargeSpeed)
    {
        speed = chargeSpeed;
    }

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
    /// <summary>
    /// �_���[�W�̏d�˂������ł��邩
    /// </summary>
	private bool isAddDamage
	{
		get;
		set;
	}
	
    /// <summary>
    /// ��~����
    /// </summary>
	public HitStop hitStop
	{
		get;
		set;
	}

    /// <summary>
    /// �_���[�W�̃p�����[�^
    /// </summary>
	public DamageParameter damageParameter
	{
		get;
		set;
	}

    public Damage(int hitstop, bool addDamage, float damage, int direction, bool ignoreDeffence)
    {
        hitStop = new HitStop(hitstop);
        isAddDamage = addDamage;
        damageParameter = new DamageParameter(direction, damage, ignoreDeffence);
    }
    
    /// <summary>
    /// �_���[�W�̒l���d�˂�������
    /// </summary>
    /// <param name="oldParameter"></param>
	public Damage AddDamage(Damage oldDamage)
	{
        if (isAddDamage)
        {
            damageParameter.damage += oldDamage.damageParameter.damage;
            return this;
        }
        return oldDamage;
	}
}

public class DamageParameter
{
	private MoveParameter moveParameter
	{
		get;
		set;
	}
	
    /// <summary>
    /// �h��͂𖳎����邩
    /// </summary>
	private bool isIgnoreDeffence
	{
		get;
		set;
	}
	
    /// <summary>
    /// �_���[�W��
    /// </summary>
	public float damage
	{
		get { return moveParameter.speed; }
		set { moveParameter.speed = value; }
	}

    /// <summary>
    /// �_���[�W�̕���
    /// </summary>
    public int direction
    {
        get { return moveParameter.direction; }
        set { moveParameter.direction = value; }
    }

    public DamageParameter(int dir, float damage, bool ignoreDeffence)
    {
        moveParameter = new MoveParameter(dir, damage);
        isIgnoreDeffence = ignoreDeffence;
    }

    /// <summary>
    /// �L�����̃p�����[�^�����Ƀ_���[�W�v�Z
    /// </summary>
    /// <param name="character"></param>
	public void DamageCalculate(CharacterParameter character)
	{
		float deffence = isIgnoreDeffence ? 1F : character.diffence.quantity;
		
		damage = damage * deffence * (Weight.MIDDLE / character.weight.quantity);
	}
	
	public Vector3 velocity
	{
		get { return moveParameter.velocity; }
	}
}

public class HitStop
{
	public int quantity
	{
		get;
		set;
	}

    public HitStop(int stopTime)
    {
        quantity = stopTime;
    }

	public void Update()
	{
		quantity--;
	}
	
	public bool isEnd
	{
		get{return quantity <= 0;}
	}
}