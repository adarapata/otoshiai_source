using UnityEngine;
using System.Collections;

public partial class Cursol : BaseCharacter
{
    /// <summary>
    /// ïséQâ¡èÛë‘
    /// </summary>
    protected class NotJoinState : BaseState
    {
        GamePad gamePad;

        public int name { get { return (int)STATENAME.NotJoin; } }


        public NotJoinState(Cursol parent, GamePad pad)
            : base(parent)
        {
            gamePad = pad;
        }

        public override int Update()
        {
            if (gamePad.IsDown(Button.A) || gamePad.IsDown(Button.Start))
            {
                WipePanel();
                SoundManager.Play(SoundManager.cursor1);
                return (int)STATENAME.Selecting;
            }

            return (int)STATENAME.Changeless;
        }

        private void WipePanel()
        {
            (stateParent as Cursol).PanelWipe(true);
        }
    }
}