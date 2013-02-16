using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttackLibrary : MonoBehaviour {
    private static AttackLibrary activeLibrary;

    public GameObject
        blow,
        chargeBlow,
        ofuda,
        amuret,
        oodama,
        ikaring,
        shibuki,
        ikari;
	// Use this for initialization
	void Start () {
        activeLibrary = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static AttackLibrary GetInstance
    {
        get { return activeLibrary; }
    }
}
