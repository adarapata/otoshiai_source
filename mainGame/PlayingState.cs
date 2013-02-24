using UnityEngine;
using System.Collections;

/// <summary>
/// ゲームが終了したかを監視するクラス
/// </summary>
public class PlayingState : IState{
    /// <summary>
    /// 終了結果
    /// </summary>
    public enum EndResult
    {
        /// <summary>
        /// 誰かが生き残った
        /// </summary>
        Persist,
        /// <summary>
        /// 全員死亡=引き分け
        /// </summary>
        Draw,
        /// <summary>
        /// まだ終わっていない
        /// </summary>
        NotEnd
    }

    public bool isEnd
    {
        get { return result != EndResult.NotEnd; }
    }

    public int name { get { return (int)MainGameManager.STATENAME.Playing; } }

    private MainGameManager parent;
    private TeamList teams;
    private EndResult result;
    public PlayingState(BetterList<Character> characters, MainGameManager manager)
    {
        parent = manager;
        teams = new TeamList(characters);
    }

    public int Update()
    {
        result = teams.Update();

        if (result == EndResult.Persist) 
        {
            parent.AddScore(teams.winTeam);
            var count = MainGameParameter.instance.GetWinCount(teams.winTeam);

            parent.SetNextState(count >= 3 ? MainGameManager.STATENAME.End : MainGameManager.STATENAME.Result);
        }
        return (int)MainGameManager.STATENAME.Changeless;
    }
}

public class TeamList {
    public BetterList<Character>[] member
    {
        get;
        private set;
    }

    public TEAMCODE winTeam
    {
        get;
        set;
    }

    public TeamList(BetterList<Character> characters)
    {
        member = new BetterList<Character>[4];
        for (int i = 0; i < member.Length; i++) { member[i] = new BetterList<Character>(); }

        foreach (var c in characters)
        {
            member[(int)c.baseParameter.team.name].Add(c);
        }
    }

    public PlayingState.EndResult Update()
    {
        BetterList<TEAMCODE> persistTeam;
        if (CheckCharaStates(out persistTeam)) 
        {
            if (persistTeam.size > 0) 
            {
                winTeam = persistTeam[0];
                return PlayingState.EndResult.Persist; 
            }
            return PlayingState.EndResult.Draw;
        }

        return PlayingState.EndResult.NotEnd;
    }

    private bool CheckCharaStates(out BetterList<TEAMCODE> persistTeam)
    {
        persistTeam = new BetterList<TEAMCODE>();
        for (int i = 0; i < member.Length; i++)
        {
            if (member[i].size <= 0) continue;

            foreach (var mem in member[i])
            {
                if (!(mem.state is CharacterDeadState))
                {
                    persistTeam.Add(mem.baseParameter.team.name);
                    break;
                }
            }
        }

        return persistTeam.size <= 1;
    }    
}