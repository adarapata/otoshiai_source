using UnityEngine;
using System.Collections;

public class BaseAttack : BaseCharacter {

    public override BaseCharacter.OBJECTTYPE Type
    {
        get
        {
            return OBJECTTYPE.Attack;
        }
    }
    /// <summary>
    /// �p�����[�^
    /// </summary>
    public AttackParameter attackParameter
    {
        get;
        set;
    }
    /// <summary>
    /// �I�u�W�F�N�g�̐e�L����
    /// </summary>
    public Character parent
    {
        get;
        set;
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerStay(Collider other)
    {
        ColliedCheck(other);
    }
    /// <summary>
    /// �Փ˂����I�u�W�F�N�g�̌^�𔻕ʂ��Ċe���\�b�h�ɔ�΂�
    /// </summary>
    /// <param name="other"></param>
    virtual protected void ColliedCheck(Collider other)
    {
        if (IsCheckSameTeam(other)) { return; }
        var enemy = other.GetComponent<BaseCharacter>();

        switch (enemy.Type)
        {
            case OBJECTTYPE.Attack:
                ColliedAttack(enemy as BaseAttack);
                break;
            case OBJECTTYPE.Box:
                ColliedBox(enemy as BaseBox);
                break;
            case OBJECTTYPE.Character:
                ColliedCharacter(enemy as Character);
                break;
        }
    }


    virtual public void Init()
    {
        SetTeamTransform(parent.baseParameter.team, parent.transform.parent);
    }

    /// <summary>
    /// �e�̍��W
    /// </summary>
    public void SetTransformParent()
    {
        transform.localPosition = parent.transform.localPosition;
    }
    /// <summary>
    /// Attack�I�u�W�F�N�g�ƐڐG�������̏���
    /// </summary>
    /// <param name="enemy"></param>
    virtual protected void ColliedAttack(BaseAttack enemy)
    {
        if (!attackParameter.attackLevel.CheckLevel(enemy.attackParameter.attackLevel))
        {
            SelfDestroy();
        }
    }

    /// <summary>
    /// Chatacter�I�u�W�F�N�g�ƐڐG�������̏���
    /// </summary>
    /// <param name="enemy"></param>
    virtual protected void ColliedCharacter(Character enemy)
    {
        enemy.ChangeHitState(attackParameter.damage);
        SelfDestroy();
    }

    /// <summary>
    /// ���ƏՓ˂����ꍇ�̏���
    /// </summary>
    /// <param name="box"></param>
    virtual protected void ColliedBox(BaseBox box)
    {
        box.Crash();
        SelfDestroy();
    }
    
    /// <summary>
    /// �O�����������ݒ肷��
    /// </summary>
    /// <param name="param"></param>
    /// <param name="damage"></param>
    public void SetMoveDirection(MoveParameter param, Damage damage)
    {
        attackParameter.damage = damage;
        baseParameter.moveParameter = param;
    }
}
