using UnityEngine;
using System.Collections;

public class HomingAmulet : BaseAttack {

    public enum STATENAME
    {
        Homing = GENERICATTACKSTATENAME.Homing,
        Changeless = GENERICATTACKSTATENAME.Changeless
    }
    private Character target;
    void Awake()
    {
        attackParameter = new AttackParameter
        {
            attackLevel = new AttackLevel(3, false)
        };
        baseParameter = new BaseParameter(sprite);
    }
	// Use this for initialization
	void Start () {
     
        TargetSearch();

        baseParameter.moveParameter = new MoveParameter(parent.frontDirection, 5F);

        if (target == null) { state = new MoveState(this); }
        else 
        {
            HomingState.Options ops = new HomingState.Options
            {
                level = HomingState.HOMINGLEVEL.Middole,
                time = 180,
                interval = 2
            };
            state = new HomingState(this, target.transform, ops);

        }
        attackParameter.damage = new Damage(30, false, 20, parent.frontDirection, false);
	}
	
	// Update is called once per frame
	void Update () {
        if (MainGameParameter.instance.Pause) return;

        sprite.transform.localEulerAngles += new Vector3(0, 0, 5);
        
        var type = state.Update();
        
        if (type != (int)STATENAME.Changeless) SelfDestroy();

        CheckOutLine();

        attackParameter.damage.damageParameter.direction = baseParameter.moveParameter.direction;
	}

    private void TargetSearch()
    {
        var targets = GameObject.FindObjectsOfType(typeof(Character)) as Character[];

        Character tar = null;
        float max = 0F;
        foreach (var ch in targets)
        {
            var now = Vector2.Distance(transform.localPosition, ch.transform.localPosition);
            if (now > max) { tar = ch; max = now; }
        }
        target = tar;
    }

    private void OnTriggerEnter(Collider other)
    {
        ColliedCheck(other.gameObject);
    }
}
