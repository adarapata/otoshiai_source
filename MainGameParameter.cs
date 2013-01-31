using UnityEngine;
using System.Collections;

public class MainGameParameter  {

    private static MainGameParameter m_instance;

    private MainGameParameter()
    { 
    }

    static public MainGameParameter instance
    {
        get 
        {
            if (m_instance == null) m_instance = new MainGameParameter();
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