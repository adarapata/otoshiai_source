using UnityEngine;
using System.Collections;

/// <summary>
/// ��{�I�ȃ}�b�v�`�b�v�N���X
/// </summary>
public class MapChip : BaseCharacter
{

    #region GUI����ݒ肳���邽�߂̃p�����[�^
    public float hp;
    public bool isAutoDeduct;
    public float autoDeduct;
    #endregion

    private MapChipParameter parameter
    {
        get;
        set;
    }
    private MAPCHIPSTATE mapchipState;

    public bool isLive
    {
        get { return parameter.hp.isLive; }
    }

    /// <summary>
    /// �}�b�v�`�b�v���W�̐ݒ�
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetMapPosition(int x, int y)
    {
        baseParameter = new BaseParameter();
        baseParameter.mapPosition = new MapPosition(x, y);

        var screenPos = baseParameter.mapPosition.GetScreenPositionByMapPosition();
        transform.localPosition = new Vector3(screenPos.x,
                                                screenPos.y,
                                                  1F);

    }

    /// <summary>
    /// ��{�p�����[�^�̏�����
    /// </summary>
    protected void InitParameter()
    {
         parameter = new MapChipParameter(this,
            isAutoDeduct ? new MapChipHP(hp, autoDeduct) : new MapChipHP(hp)
        );

        animation = new MapChipAnimationController(sprite);
    }
	// Use this for initialization
	void Start () {
        InitParameter();
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