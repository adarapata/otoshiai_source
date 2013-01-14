using UnityEngine;
using System.Collections;


public class MainGameManager : MonoBehaviour
{
    public CharacterLibrary charas;
    public GameObject mainPanel, mapChipPanel;
    private MainGameParameter parameter;
    public GameObject[] parameterWindows;
    // Use this for initialization
    void Start()
    {
        parameter = MainGameParameter.instance;
        parameter.players = new BetterList<Player>();
        parameter.players.Add(new Player());
        parameter.players[0].character = charas.reimu;
        CraeteCharacter(parameter.players[0]);
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
        chara.transform.parent = mainPanel.transform;
        chara.transform.localScale = new Vector3(1F, 1F, 1F);
        chara.layer = 0;

        parameterWindows[0].GetComponent<CharacterParameterWindow>().Init(chara.GetComponent<Character>(), 0);
    }
}