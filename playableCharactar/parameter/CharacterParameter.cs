using UnityEngine;
using System.Collections;

public class CharacterParameter
{
    /// <summary>
    /// キャラの攻撃力
    /// </summary>
	public Power power
	{
		get;
		set;
	}
    /// <summary>
    /// 防御力
    /// </summary>
	public Diffence diffence
	{
		get;
		set;
	}
	/// <summary>
	/// 体重
	/// </summary>
	public Weight weight
	{
		get;
		set;
	}
	/// <summary>
	/// スタミナ
	/// </summary>
	public Stamina stamina
	{
		get;
		set;
	}

    /// <summary>
    /// 所有ダメージ
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
	/// スタミナ回復
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
    /// ダメージの重ねがけができるか
    /// </summary>
	private bool isAddDamage
	{
		get;
		set;
	}
	
    /// <summary>
    /// 停止時間
    /// </summary>
	public HitStop hitStop
	{
		get;
		set;
	}

    /// <summary>
    /// ダメージのパラメータ
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
    /// ダメージの値を重ねがけする
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
    /// 防御力を無視するか
    /// </summary>
	private bool isIgnoreDeffence
	{
		get;
		set;
	}
	
    /// <summary>
    /// ダメージ量
    /// </summary>
	public float damage
	{
		get { return moveParameter.speed; }
		set { moveParameter.speed = value; }
	}

    /// <summary>
    /// ダメージの方向
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
    /// キャラのパラメータを元にダメージ計算
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