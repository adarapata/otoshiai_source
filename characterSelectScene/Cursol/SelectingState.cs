using UnityEngine;
using System.Collections;

public partial class Cursol : BaseCharacter
{
    /// <summary>
    /// 選択状態
    /// </summary>
    protected class SelectingState : BaseState
    {
        private Cursol cursol;
        private Player player;
        private Vector3 velocity;

        public int name { get { return (int)STATENAME.Selecting; } }

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
        public override int Update()
        {
            if (player.gamepad.IsPushStick(Stick.Right)) { MoveRight(); }
            if (player.gamepad.IsPushStick(Stick.Left)) { MoveLeft(); }

            if (player.gamepad.IsDown(Button.A))
            {
                SoundManager.Play(SoundManager.cursor1);
                SettingCollieder();
                return (int)STATENAME.Decide;
            }

            if (player.gamepad.IsDown(Button.D)) { return (int)Leave(); }

            return (int)STATENAME.Changeless;
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
        private STATENAME Leave()
        {
            SoundManager.Play(SoundManager.cursor2);
            cursol.RejectScaling();
            WipePanel();
            return STATENAME.NotJoin;
        }

        private void WipePanel()
        {
            (stateParent as Cursol).PanelWipe(false);
        }
    }
}
