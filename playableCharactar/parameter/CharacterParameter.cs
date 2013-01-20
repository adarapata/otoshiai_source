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

    /// <summary>
    /// ���G��ԃp�����[�^
    /// </summary>
    public Invincibly invincibly
    {
        get;
        set;
    }

    public void Update()
    {
        if (invincibly.flag) invincibly.Update();
    }
}

/// <summary>
/// ���G������Ǘ�����N���X
/// </summary>
public class Invincibly
{
    /// <summary>
    /// �_���[�W���󂯂Ȃ���Ԃ��ǂ���
    /// </summary>
    public bool flag
    {
        get;
        private set;
    }

    /// <summary>
    /// ���G��Ԃ̎c����(�t���[����)
    /// </summary>
    public int time
    {
        get;
        private set;
    }

    /// <summary>
    /// ���G���Ԃ̐ݒ�
    /// </summary>
    /// <param name="setTime">���G�t���[����</param>
    /// <param name="isOverride">���łɖ��G��Ԃ̎��ɁA���Ԃ��㏑�����邩</param>
    public void Start(int setTime, bool isOverride)
    {
        if (flag && !isOverride) return;
        flag = true;
        time = setTime;
    }

    public void Update()
    {
        flag = time-- > 0;
    }
}