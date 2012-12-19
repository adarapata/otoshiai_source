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