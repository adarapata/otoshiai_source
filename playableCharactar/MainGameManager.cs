using UnityEngine;
using System.Collections;


public class MainGameManager : MonoBehaviour
{
    public CharacterLibrary charas;
    public GameObject mainPanel, mapChipPanel;

    // Use this for initialization
    void Start()
    {
        CraeteCharacter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// キャラクターをシーンに生成する
    /// </summary>
    private void CraeteCharacter()
    {
        var chara = GameObject.Instantiate(charas.reimu) as GameObject;
        chara.transform.parent = mainPanel.transform;
        chara.transform.localScale = new Vector3(1F, 1F, 1F);
    }
}