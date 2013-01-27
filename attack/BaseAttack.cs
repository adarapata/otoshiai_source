using UnityEngine;
using System.Collections;

public class BaseAttack : BaseCharacter {

    /// <summary>
    /// パラメータ
    /// </summary>
    public AttackParameter attackParameter
    {
        get;
        set;
    }
    /// <summary>
    /// オブジェクトの親キャラ
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
    /// 衝突したオブジェクトの型を判別して各メソッドに飛ばす
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
    /// Attackオブジェクトと接触した時の処理
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
    /// Chatacterオブジェクトと接触した時の処理
    /// </summary>
    /// <param name="enemy"></param>
    virtual protected void ColliedCharacter(Character enemy)
    {
        enemy.ChangeHitState(attackParameter.damage);
        Destroy(gameObject);
    }
}
