using UnityEngine;
using System.Collections;

public class CharacterSelectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var bgm = MusicManager.GetInstance();
        if (bgm.SetBgm(TrackName.select)) { bgm.Play(); }
	}
	
	// Update is called once per frame
	void Update () {

	}


    static public void ChangeMainScene()
    {
        if (MainGameParameter.instance.players.size >= 2)
        {
            MusicManager.GetInstance().Stop();
            Application.LoadLevel("mainScene");
        }
    }

    static public void AddPlayer(Player p)
    {
        MainGameParameter.instance.players.Add(p);
    }
}
