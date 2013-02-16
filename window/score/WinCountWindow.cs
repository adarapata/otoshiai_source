using UnityEngine;
using System.Collections;

/// <summary>
/// 勝利数を表示するウィンドウ
/// </summary>
public class WinCountWindow : MonoBehaviour {

    public UISprite charaSprite
    {
        get;
        set;
    }
    public TEAMCODE team
    {
        get;
        set;
    }
    public GameObject star;
	// Use this for initialization
    void Start()
    {

    }

    public void Init(UISprite sprite, TEAMCODE _team)
    {
        charaSprite = sprite;
        team = _team;

        CreateStar();
        CreateCharaSprite();
    }

	// Update is called once per frame
    void Update()
    {
        if (charaSprite == null) { Destroy(gameObject); return; }
    }

    private void CreateStar()
    {
        int winCount = MainGameParameter.instance.GetWinCount(team);
        for (int i = 0; i < winCount; i++)
        {
            var st = Instantiate(star) as GameObject;
            st.transform.parent = transform;
            st.transform.localScale = Vector3.one;
            st.transform.localPosition = new Vector3(32 * i, 0);
        }
    }

    public void CreateAnimationStar()
    {
        int winCount = MainGameParameter.instance.GetWinCount(team);
        var st = Instantiate(star) as GameObject;
        st.transform.parent = transform;
        st.transform.localScale = new Vector3(2F, 2F);
        st.transform.localPosition = new Vector3(transform.localPosition.x + 32 * winCount, 500, 0);
        st.GetComponent<Star>().StartAnimation();
    }

    private void CreateCharaSprite()
    {
        charaSprite.spriteName = "down0";
        var chara = Instantiate(charaSprite.gameObject) as GameObject;
        chara.transform.parent = transform;
        chara.transform.localScale = new Vector3(24, 32, 1);
        chara.transform.localPosition = new Vector3(-32, 0);
    }
}
