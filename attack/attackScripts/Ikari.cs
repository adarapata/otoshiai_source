using UnityEngine;
using System.Collections;

public class Ikari : BaseAttack
{
    public enum STATENAME
    {
        Move = 0,
        Return,
        Changeless = GENERICATTACKSTATENAME.Changeless
    }

    private MapManager mapManager;
    public bool IsOutMap
    {
        get;
        private set;
    }

    void Awake()
    {
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(5, false)
        };
        baseParameter = new BaseParameter(sprite);
        baseParameter.mapPosition = new MapPosition(0, 0);
    }
    // Use this for initialization
    void Start()
    {
        mapManager = GameObject.Find("map_manager").GetComponent<MapManager>();

        attackParameter.damage = new Damage(20, false, 30, parent.frontDirection, false);
        baseParameter.moveParameter = new MoveParameter(parent.frontDirection, 0F);


        state = new IkariMoveState(this);
        PolarCoordinates.RotateAngles(sprite.gameObject.transform, baseParameter.moveParameter.direction+180);

    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameParameter.instance.Pause) return;

        state.Update();

        CheckOutLine();

        CheckMaps();
    }

    private void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other);
    }

    protected override void ColliedCharacter(Character enemy)
    {
        enemy.ChangeHitState(attackParameter.damage);
    }

    public void ChangeNextState(STATENAME next)
    {
        if (next == STATENAME.Return) 
        { state = new IkariReturnState(this, parent as Murasa); }
    }
    /// <summary>
    /// マップを調べて落下判定のチェック
    /// </summary>
    protected void CheckMaps()
    {
        baseParameter.mapPosition.SetChipPositionByScreenPosition(transform.localPosition);
        //乗っているマップがnullもしくは壊れているなら落下
        var onMapChip = mapManager.GetMapChip(baseParameter.mapPosition);
        IsOutMap = onMapChip == null;
    }
}
