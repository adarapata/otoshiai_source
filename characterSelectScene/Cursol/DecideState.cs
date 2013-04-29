using UnityEngine;
using System.Collections;

public partial class Cursol : BaseCharacter
{
    /// <summary>
    /// Œˆ’èó‘Ô
    /// </summary>
    protected class DecideState : BaseState
    {
        private Player player;

        public int name { get { return (int)STATENAME.Decide; } }

        public DecideState(Cursol parent, Player p)
            : base(parent)
        {
            player = p;
        }

        public override int Update()
        {
            if (player.gamepad.IsDown(Button.D))
            {
                MainGameParameter.instance.players.Remove(player);
                SoundManager.Play(SoundManager.cursor2);
                return (int)STATENAME.Selecting;
            }

            if (player.gamepad.IsDown(Button.A) || player.gamepad.IsDown(Button.Start))
            {
                CharacterSelectManager.ChangeMainScene();
            }

            return (int)STATENAME.Changeless;
        }
    }
}
