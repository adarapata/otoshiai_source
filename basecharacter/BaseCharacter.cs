using UnityEngine;
using System.Collections;

/// <summary>
/// �Q�[�����̃I�u�W�F�N�g�̊�ՃN���X
/// </summary>
public class BaseCharacter : MonoBehaviour {
	
	public UISprite sprite;
	/// <summary>
	/// ��ԁ@�@�@get;set;
	/// </summary>
	/// <value>
	/// The state.
	/// </value>
	protected IState state {
		get;
		set;
	}
	
	public IAnimationController animation
	{
		get;
		set;
	}
	
	/// <summary>
	/// �I�u�W�F�N�g�̊�{�p�����[�^  get;set;
	/// </summary>
	/// <value>
	/// The base parameter.
	/// </value>
	public BaseParameter baseParameter {
		get;
		set;
	}
	

	// Use this for initialization
	void Start () {		
        sprite = GetComponent<UISprite>();
		state = new BaseState(this);
		baseParameter = new BaseParameter(sprite);
	}
	
	// Update is called once per frame
	void Update () {
		state.Update();
	}

    /// <summary>
    /// �����`�[�����ǂ�����Ԃ�
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    protected bool IsCheckSameTeam(Collider other)
    {
        return transform.parent.Equals(other.gameObject.transform.parent);
    }
}

