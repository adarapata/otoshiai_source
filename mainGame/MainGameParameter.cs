using UnityEngine;
using System.Collections;

public class MainGameParameter  {

    private static MainGameParameter m_instance;

    private MainGameParameter()
    {
        TeamwinCount = new int[4];
        winCount = 3;
    }

    static public MainGameParameter instance
    {
        get 
        {
            if (m_instance == null)
            {
                m_instance = new MainGameParameter();
                m_instance.players = new BetterList<Player>();
            }
            return m_instance;
        }
    }

    public BetterList<Player> players
    {
        get;
        set;
    }

    public string stage
    {
        get;
        set;
    }

    /// <summary>
    /// ゲームクリアに必要な勝利数
    /// </summary>
    public int winCount
    {
        get;
        set;
    }

    public bool Pause
    {
        get;
        set;
    }

    private int[] TeamwinCount { get; set; }

    /// <summary>
    /// 指定したチームの勝利数を１増やす
    /// それにより勝利数が条件を満たしたらtrueが買える
    /// </summary>
    /// <param name="code"></param>
    public bool AddWincount(TEAMCODE code)
    {
        TeamwinCount[(int)code]++;
        return TeamwinCount[(int)code] >= winCount;
    }
    public int GetWinCount(TEAMCODE code)
    {
        return TeamwinCount[(int)code];
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Reflesh()
    {
        players.Clear();
        for (int i = 0; i < TeamwinCount.Length; i++)
        {
            TeamwinCount[i] = 0;
        }
    }

    /// <summary>
    /// デバッグ用にとりあえずデータをでっち上げる
    /// </summary>
    public void CreateTemplateData()
    {
        CharacterLibrary lib = GameObject.Find("Library").GetComponent<CharacterLibrary>();
        players = new BetterList<Player>();

        for (int i = 0; i < 2; i++)
        {
            Player p = new Player(i);
            GameObject chara = lib.reimu;
            p.character = chara;
            GamePad pad = new GamePad(i);
            p.gamepad = pad;
            p.team = new Team((TEAMCODE)i);
            players.Add(p);
        }
    }

}