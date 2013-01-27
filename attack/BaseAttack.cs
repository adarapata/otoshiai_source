using UnityEngine;
using System.Collections;

public class BaseAttack : BaseCharacter {

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
        if (IsCheckSameTeam(other)) return;

        var enemy = other.GetComponent<BaseCharacter>();

        if (enemy is BaseAttack) { ColliedAttack(enemy as BaseAttack); return; }
        if (enemy is Character) { ColliedCharacter(enemy as Character); return; }
    }


    virtual protected void Init()
    {
        SetTeamTransform(parent.baseParameter.team, parent.transform.parent);
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
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Chatacter�I�u�W�F�N�g�ƐڐG�������̏���
    /// </summary>
    /// <param name="enemy"></param>
    virtual protected void ColliedCharacter(Character enemy)
    {
        enemy.ChangeHitState(attackParameter.damage);
        Destroy(gameObject);
    }
}
