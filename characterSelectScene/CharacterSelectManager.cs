using UnityEngine;
using System.Collections;

public class CharacterSelectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MusicManager.CreateInstance();
        var bgm = MusicManager.GetInstance();
        if (bgm.SetBgm(TrackName.select)) { bgm.Play(); }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
