using UnityEngine;
using System.Collections;

public partial class BaseBox : BaseCharacter {

    public enum STATENAME : int
    {
        Stay = 0,
        Move = GENERICSTATENAME.Move,
        Fall = GENERICSTATENAME.Fall,
        Changeless = GENERICSTATENAME.Changeless
    }
    protected MapManager mapManager;

    public override BaseCharacter.OBJECTTYPE Type
    {
        get
        {
            return OBJECTTYPE.Box;
        }
    }
	// Use this for initialization
	void Start () {
        Init();
	}
	

	// Update is called once per frame
	void Update () {
        ScriptUpdate();
	}

    virtual protected void Init()
    {
        //マップ座標を設定
        mapManager = FindObjectOfType(typeof(MapManager)) as MapManager;
        baseParameter = new BaseParameter(sprite);
        baseParameter.mapPosition = new MapPosition(0, 0);
        //初期はStay状態
        state = new BoxStayState(this);
    }

    virtual protected void ScriptUpdate()
    {
        if (MainGameParameter.instance.Pause) return;

        var nextSate = state.Update();
        if (nextSate != (int)STATENAME.Changeless) { Destroy(gameObject); }

        if (CheckMaps()) { ChangeFallState(); }
    }

    /// <summary>
    /// 箱が壊れる。オーバーライド化
    /// </summary>
    virtual public void Crash()
    {
        Debug.Log("crach");
        SoundManager.Play(SoundManager.hitLight);
        SelfDestroy();
    }

    /// <summary>
    /// 箱が押される
    /// </summary>
    /// <param name="dir"></param>
    virtual public void Put(int dir,float power)
    {
        //移動状態に遷移
        baseParameter.moveParameter = new MoveParameter(dir, power);
        state = new MoveState(this);

        SoundManager.Play(SoundManager.attackLight);
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedOnMoveState(other);
    }

    /// <summary>
    /// 移動状態で接触した場合の処理
    /// </summary>
    /// <param name="other"></param>
    protected void ColliedOnMoveState(Collider other)
    {
        if (state.name != (int)STATENAME.Move) { return; }

        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy.Type == OBJECTTYPE.Character)
        {
            ColliedCharacter(enemy as Character);
        }
    }

    protected bool CheckMaps()
    {
        if (state.name == (int)STATENAME.Fall) return false;
        //マップの範囲外にいたら落下
        bool isInside = baseParameter.mapPosition.SetChipPositionByScreenPosition(transform.localPosition);
        if (!isInside) { return true; }

        //乗っているマップがnullもしくは壊れているなら落下
        var onMapChip = mapManager.GetMapChip(baseParameter.mapPosition);
        if (onMapChip == null || !onMapChip.isLive) { return true; }

        return false;
    }

    /// <summary>
    /// 落下状態に移行
    /// </summary>
    protected void ChangeFallState()
    {
        state = new FallState(this);
        SoundManager.Play(SoundManager.fall);
    }

    /// <summary>
    /// 移動状態でキャラにぶつかったばあい、ダメージを与える
    /// </summary>
    /// <param name="enemy"></param>
    virtual protected void ColliedCharacter(Character enemy)
    {
        Damage d = new Damage(20, false, 20, baseParameter.moveParameter.direction, false);
        (enemy as Character).ChangeHitState(d);
        SelfDestroy();
    }

    public Vector3 PositionFix(Vector3 enemyPos)
    {
        //角度求める
        Vector2 fix = enemyPos - transform.localPosition;
        int angleA = (int)Vector2.Angle(Vector2.one, fix);
        int angleB = (int)Vector2.Angle(new Vector2(-1, 1), fix);
        bool x, y;
        x = angleA > 0 & angleA <= 90;
        y = angleB > 0 & angleB <= 90;

        Vector3 pos = enemyPos;
        Vector2 boxis = transform.localPosition;

        if (x)
        {
            if (y) pos.y = boxis.y + 16 + 10;
            else pos.x = boxis.x + 16 + 6;
        }
        else
        {
            if (y) pos.x = boxis.x - 16 - 6;
            else pos.y = boxis.y - 16 - 10;
        }

        return pos;
    }
}
