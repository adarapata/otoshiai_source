using UnityEngine;
using System.Collections;

public class BaseBox : BaseCharacter {

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
        //�}�b�v���W��ݒ�
        mapManager = FindObjectOfType(typeof(MapManager)) as MapManager;
        baseParameter = new BaseParameter(sprite);
        baseParameter.mapPosition = new MapPosition(0, 0);
        //������Stay���
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
    /// ��������B�I�[�o�[���C�h��
    /// </summary>
    virtual public void Crash()
    {
        SoundManager.Play(SoundManager.hitLight);
        SelfDestroy();
    }

    /// <summary>
    /// �����������
    /// </summary>
    /// <param name="dir"></param>
    virtual public void Put(int dir,float power)
    {
        //�ړ���ԂɑJ��
        baseParameter.moveParameter = new MoveParameter(dir, power);
        state = new MoveState(this);

        SoundManager.Play(SoundManager.attackLight);
    }

    void OnTriggerEnter(Collider other)
    {
        ColliedOnMoveState(other);
    }

    /// <summary>
    /// �ړ���ԂŐڐG�����ꍇ�̏���
    /// </summary>
    /// <param name="other"></param>
    protected void ColliedOnMoveState(Collider other)
    {
        if (state.name != (int)STATENAME.Move) return;

        var enemy = other.GetComponent<BaseCharacter>();
        if (enemy is Character)
        {
            ColliedCharacter(enemy as Character);
        }
    }

    protected bool CheckMaps()
    {
        if (state.name == (int)STATENAME.Fall) return false;
        //�}�b�v�͈̔͊O�ɂ����痎��
        bool isInside = baseParameter.mapPosition.SetChipPositionByScreenPosition(transform.localPosition);
        if (!isInside) { return true; }

        //����Ă���}�b�v��null�������͉��Ă���Ȃ痎��
        var onMapChip = mapManager.GetMapChip(baseParameter.mapPosition);
        if (onMapChip == null || !onMapChip.isLive) { return true; }

        return false;
    }

    /// <summary>
    /// ������ԂɈڍs
    /// </summary>
    protected void ChangeFallState()
    {
        state = new FallState(this);
        SoundManager.Play(SoundManager.fall);
    }

    /// <summary>
    /// �ړ���ԂŃL�����ɂԂ������΂����A�_���[�W��^����
    /// </summary>
    /// <param name="enemy"></param>
    virtual protected void ColliedCharacter(Character enemy)
    {
        Damage d = new Damage(20, false, 20, baseParameter.moveParameter.direction, false);
        (enemy as Character).ChangeHitState(d);
        SelfDestroy();
    }
}
