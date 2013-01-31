using UnityEngine;
using System.Collections;


public class MainGameManager : MonoBehaviour
{
    public GameObject mapChipPanel;
    private MainGameParameter parameter;
    public GameObject[] parameterWindows;
    public GameObject[] teamPanels;
    // Use this for initialization
    void Start()
    {
        parameter = MainGameParameter.instance;
        parameter.CreateTemplateData();
        foreach (var player in parameter.players)
        {
            CraeteCharacter(player);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            var param = MainGameParameter.instance;
            param.Pause = !param.Pause;
        }
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
    }
}