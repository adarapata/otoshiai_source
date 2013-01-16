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
        
    }

    /// <summary>
    /// キャラクターをシーンに生成する
    /// </summary>
    private void CraeteCharacter(Player player)
    {
        var chara = GameObject.Instantiate(player.character) as GameObject;
        var script = chara.GetComponent<Character>();
        script.parent = player;
        script.SendMessage("Start");
        chara.transform.parent = teamPanels[(int)script.baseParameter.team.name].transform;
        chara.transform.localScale = Vector3.one;

        parameterWindows[player.number].GetComponent<CharacterParameterWindow>().Init(script, player.number);
    }
}