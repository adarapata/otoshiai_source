using UnityEngine;
using System.Collections;

public class MapChip : BaseCharacter {

    public float hp;
    public bool isAutoDeduct;
    public float autoDeduct;

    private MapChipParameter parameter
    {
        get;
        set;
    }
    private MAPCHIPSTATE mapchipState;

    public void SetMapPosition(int x, int y)
    {
        baseParameter = new BaseParameter();
        baseParameter.mapPosition = new MapPosition(x, y);

        var screenPos = baseParameter.mapPosition.GetScreenPositionByMapPosition();
        transform.localPosition = new Vector3(screenPos.x,
                                                screenPos.y,
                                                  transform.localPosition.z);

    }

	// Use this for initialization
	void Start () {
        SetMapPosition(0, 0);

        parameter = new MapChipParameter(this,
            isAutoDeduct ? new MapChipHP(hp, autoDeduct) : new MapChipHP(hp)
        );

        animation = new MapChipAnimationController(sprite);
	}
	
	// Update is called once per frame
	void Update () {
        parameter.Update();
	}

    public void SetDamage(float damage)
    {
        parameter.hp.Damage(damage);
    }
}