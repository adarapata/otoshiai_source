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
    /// 親の座標
    /// </summary>
    public void SetTransformParent()
    {
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
            SelfDestroy();
        }
    }

    /// <summary>
    /// Chatacterオブジェクトと接触した時の処理
    /// </summary>
    /// <param name="enemy"></param>
    virtual protected void ColliedCharacter(Character enemy)
    {
        enemy.ChangeHitState(attackParameter.damage);
        SelfDestroy();
    }

    /// <summary>
    /// 箱と衝突した場合の処理
    /// </summary>
    /// <param name="box"></param>
    virtual protected void ColliedBox(BaseBox box)
    {
        box.Crash();
        SelfDestroy();
    }
    
    /// <summary>
    /// 外部から向きを設定する
    /// </summary>
    /// <param name="param"></param>
    /// <param name="damage"></param>
    public void SetMoveDirection(MoveParameter param, Damage damage)
    {
        attackParameter.damage = damage;
        baseParameter.moveParameter = param;
    }
}
