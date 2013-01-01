using UnityEngine;
using System.Collections;

public class MapChip : BaseCharacter {

    private MapChipParameter parameter
    {
        get;
        set;
    }



	// Use this for initialization
	void Start () {
        parameter = new MapChipParameter
        {
            hp = new MapChipHP
            {
                strength = 600,
                autoDeduct = 0.1F,
                isAutoDeduct = true
            }
        };

        
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void SetDamage(float damage)
    {
        parameter.hp.Damage(damage);
    }
}
