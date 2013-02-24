using UnityEngine;
using System.Collections;

/// <summary>
/// ��ԃN���X�̊�ՃN���X
/// </summary>
public class BaseState :IState {

    virtual public int name { get { return 4; } }

	/// <summary>
	/// ���̏�Ԃ����I�u�W�F�N�g
	/// </summary>
	protected BaseCharacter stateParent
	{
		get;
		set;
	}
	
	/// <summary>
	/// ���������̏�Ԃ����I�u�W�F�N�g��ݒ肷��
	/// </summary>
	/// <param name='baseCharacter'>
	/// Base Character.
	/// </param>
	public BaseState(BaseCharacter baseCharacter)
	{
		stateParent = baseCharacter;
	}
	
	virtual public int Update()
	{
        return 0;
	}
}