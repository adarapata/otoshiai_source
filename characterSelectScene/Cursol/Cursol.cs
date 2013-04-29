using UnityEngine;
using System.Collections;

/// <summary>
/// �L�����I���J�[�\��
/// </summary>
public partial class Cursol : BaseCharacter {

    public enum STATENAME
    {
        Selecting = 0,
        NotJoin,
        Decide,
        Changeless = GENERICSTATENAME.Changeless
    }

    public int playerNumber;
    public GameObject parentPanel;
    private Player parent;
    private int number=0;
    private GamePad pad;
    private const int MAX_LENGTH = 3;
    
	// Use this for initialization
	void Start () {
        pad = new GamePad(playerNumber);
        parent = new Player(playerNumber);
        parent.gamepad = pad;
        parent.team = new Team((TEAMCODE)playerNumber);

        sprite.color = new Color(1F, 1F, 1F, 0.7F);

        state = new NotJoinState(this, pad);
	}
	
	// Update is called once per frame
	void Update () {
        pad.Update();

        var nextState = state.Update();

        if (nextState != (int)STATENAME.Changeless) { state = ChangeState((STATENAME)nextState); }


	}

    private BaseState ChangeState(STATENAME next)
    {
        switch (next)
        {
            case STATENAME.NotJoin:
                return new NotJoinState(this, pad);
            case STATENAME.Selecting:
                return new SelectingState(this, parent);
            case STATENAME.Decide:
                return new DecideState(this,parent);
        }

        return null;
    }

    /// <summary>
    /// ���E�Ɉړ�����A�j���[�V�����𐶐�����
    /// </summary>
    /// <param name="velo"></param>
    public void Tween(Vector3 velo)
    {
        var tween = gameObject.AddComponent<TweenPosition>();
        tween.from = transform.localPosition;
        tween.to = transform.localPosition + velo;
        tween.duration = 0.2F;
        tween.eventReceiver = gameObject;
        tween.callWhenFinished = "End";
        tween.Play(true);

        number += velo.x < 0 ? -1 : 1;
    }
    /// <summary>
    /// �J�[�\�����g��k������A�j���[�V�����ǉ�
    /// </summary>
    public void Scaling()
    {
        TweenScale scale = gameObject.AddComponent<TweenScale>();
        scale.from = new Vector3(0.8F, 0.8F, 1f);
        scale.to = Vector3.one;
        scale.duration = 0.5F;
        scale.style = UITweener.Style.PingPong;
        scale.Play(true);
    }
    /// <summary>
    /// �X�P�[�����O�������폜
    /// </summary>
    public void RejectScaling()
    {
        var scall = gameObject.GetComponent<TweenScale>();
        if (scall != null) { Destroy(scall); }
    }

    void OnTriggerEnter(Collider other)
    {
        var carrier = other.gameObject.GetComponent<CharacterSelectIcon>();
        SetCharacter(carrier.character);
    }

    private void SetCharacter(GameObject character)
    {
        parent.character = character;
        
        var box = gameObject.GetComponent<BoxCollider>();
        if (box != null)
        {
            Destroy(box);
        }

        var scale = gameObject.GetComponent<TweenScale>();
        if (scale != null) { Destroy(scale); }
        CharacterSelectManager.AddPlayer(parent);
    }

    /// <summary>
    /// �Փ˔����t����
    /// </summary>
    public void SettingCollieder()
    {
        var box = gameObject.AddComponent<BoxCollider>();
        box.size = Vector3.one;
        box.isTrigger = true;
    }

    public bool CanMove(bool isRight)
    {
        if (isRight) { return number < MAX_LENGTH - 1; }
        else return number > 0;
    }

    /// <summary>
    /// TweenPosition�X�N���v�g���I��������
    /// </summary>
    private void End()
    {
        var tween = gameObject.GetComponent<TweenPosition>();
        if (tween != null)
        {
            Destroy(tween);
        }
    }

    public void PanelWipe(bool open)
    {
        var tween = parentPanel.GetComponent<TweenPosition>();
        tween.from.y = tween.to.y = parentPanel.transform.localPosition.y;
        tween.Play(open);
    }
}
