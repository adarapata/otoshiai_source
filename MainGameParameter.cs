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


}

public class Player
{
    public IGamePad gamePad
    {
        get;
        set;
    }

    public GameObject character
    {
        get;
        set;
    }
}