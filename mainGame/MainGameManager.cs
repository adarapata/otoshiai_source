using UnityEngine;
using System.Collections;


public class MainGameManager : MonoBehaviour
{
    public GameObject mapChipPanel;
    private MainGameParameter parameter;
    public GameObject[] parameterWindows;
    public GameObject[] teamPanels;
    public BetterList<Character> characters
    {
        get;
        private set;
    }

    IState state;
    // Use this for initialization
    void Start()
    {
        MusicManager.CreateInstance();
        var music = MusicManager.GetInstance();
        if (music.SetBgm(TrackName.pinko)) 
        {
            music.Play(); 
        };


        characters = new BetterList<Character>();

        parameter = MainGameParameter.instance;
        //parameter.CreateTemplateData();
        foreach (var player in parameter.players)
        {
            CraeteCharacter(player);
        }

        state = new StartState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            var param = MainGameParameter.instance;
            param.Pause = !param.Pause;
        }

        state.Update();
    }

    /// <summary>
    /// キャラクターをシーンに生成する
    /// </summary>
    private void CraeteCharacter(Player player)
    {
        if (player.number > parameterWindows.Length-1) return;

        var chara = GameObject.Instantiate(player.character) as GameObject;
        var script = chara.GetComponent<Character>();
        script.parent = player;
        script.SetTeamTransform(player.team, teamPanels[(int)player.team.name].transform);

        parameterWindows[player.number].GetComponent<CharacterParameterWindow>().Init(script, player.number);

        characters.Add(script);
    }

    /// <summary>
    /// 勝利したチームに星を追加する
    /// </summary>
    /// <param name="winTeam"></param>
    public void AddScore(TEAMCODE winTeam)
    {
        var param = MainGameParameter.instance;
        
        foreach (var window in parameterWindows)
        {
            if (window == null) { continue; }

            var script = window.GetComponent<CharacterParameterWindow>();
            if (script.character.baseParameter.team.name == winTeam)
            {
                script.AddStar();
            }
        }

        param.AddWincount(winTeam);

    }

    public void SetNextState(System.Type next)
    {
        if (next == typeof(PlayingState)) { state = new PlayingState(characters, this); }
        if (next == typeof(ResultState)) { state = new ResultState(this); }
        if (next == typeof(EndState)) { state = new EndState(this); }

    }

    /// <summary>
    /// 再度、シーンを読み込む
    /// </summary>
    public void Retry()
    {
        Application.LoadLevel("mainScene");
    }
    public void BackSelectScene()
    {
        MainGameParameter.instance.Reflesh();
        MusicManager.GetInstance().Stop();
        Application.LoadLevel("characterSelect");
    }
}