using UnityEngine;
using System.Collections;

/// <summary>
/// キャラ選択カーソル
/// </summary>
public class Cursol : BaseCharacter {

    /// <summary>
    /// 選択状態
    /// </summary>
    public class SelectingState : BaseState
    {
        private Cursol cursol;
        private Player player;
        private Vector3 velocity;

        public SelectingState(Cursol parent, Player p)
            : base(parent)
        {
            cursol = parent;
            player = p;
            Vector3 scale = Vector3.one;
            velocity = new Vector3(128F * scale.x, 0, 0);

            cursol.Scaling();
        }

        // Update is called once per frame
        public override System.Type Update()
        {
            if (player.gamepad.IsPushStick(Stick.Right)) { MoveRight(); }
            if (player.gamepad.IsPushStick(Stick.Left)) { MoveLeft(); }

            if (player.gamepad.IsDown(Button.A))
            {
                SoundManager.Play(SoundManager.cursor1);
                SettingCollieder();
                return typeof(DecideState);
            }

            if (player.gamepad.IsDown(Button.D)) { return Leave(); }

            return null;
        }

        private void MoveLeft()
        {
            if (stateParent.gameObject.GetComponent<TweenPosition>() != null) { return; }

            if (cursol.CanMove(false))
            {
                Tween(-velocity);
            }

        }

        private void MoveRight()
        {
            if (stateParent.gameObject.GetComponent<TweenPosition>() != null) { return; }

            if (cursol.CanMove(true))
            {
                Tween(velocity);
            }
        }

        /// <summary>
        /// 左右に移動するアニメーションを生成する
        /// </summary>
        /// <param name="velo"></param>
        private void Tween(Vector3 velo)
        {
            cursol.Tween(velo);
        }

        /// <summary>
        /// 衝突判定を付ける
        /// </summary>
        private void SettingCollieder()
        {
            cursol.SettingCollieder();
        }

        /// <summary>
        /// ゲームに不参加とする
        /// </summary>
        private System.Type Leave()
        {
            SoundManager.Play(SoundManager.cursor2);
            cursol.RejectScaling();
            WipePanel();
            return typeof(NotJoinState);
        }

        private void WipePanel()
        {
            (stateParent as Cursol).PanelWipe(false);
        }
    }

    /// <summary>
    /// 不参加状態
    /// </summary>
    public class NotJoinState : BaseState
    {
        GamePad gamePad;
        public NotJoinState(Cursol parent, GamePad pad)
            : base(parent)
        {
            gamePad = pad;
        }

        public override System.Type Update()
        {
            if (gamePad.IsDown(Button.A) || gamePad.IsDown(Button.Start))
            {
                WipePanel();
                SoundManager.Play(SoundManager.cursor1);
                return typeof(SelectingState);
            }

            return null;
        }

        private void WipePanel()
        {
            (stateParent as Cursol).PanelWipe(true);
        }
    }

    /// <summary>
    /// 決定状態
    /// </summary>
    public class DecideState : BaseState
    {
        private Player player;
        public DecideState(Cursol parent, Player p)
            : base(parent)
        {
            player = p;
        }

        public override System.Type Update()
        {
            if (player.gamepad.IsDown(Button.D))
            {
                MainGameParameter.instance.players.Remove(player);
                SoundManager.Play(SoundManager.cursor2);
                return typeof(SelectingState);
            }

            if (player.gamepad.IsDown(Button.A) || player.gamepad.IsDown(Button.Start))
            {
                if (MainGameParameter.instance.players.size >= 2)
                {
                        MusicManager.GetInstance().Stop();
                        Application.LoadLevel("mainScene");
                }
            }

            return null;
        }
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

        if (nextState != null) { state = ChangeState(nextState); }


	}

    private BaseState ChangeState(System.Type next)
    {
        if (next == typeof(NotJoinState)) { return new NotJoinState(this, pad); }
        if (next == typeof(SelectingState)) { return new SelectingState(this, parent); }
        if (next == typeof(DecideState)) { return new DecideState(this,parent); }

        return null;
    }

    /// <summary>
    /// 左右に移動するアニメーションを生成する
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
    /// カーソルが拡大縮小するアニメーション追加
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
    /// スケーリング処理を削除
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
        MainGameParameter.instance.players.Add(parent);
    }

    /// <summary>
    /// 衝突判定を付ける
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
    /// TweenPositionスクリプトを終了させる
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
