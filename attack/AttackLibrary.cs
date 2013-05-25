using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttackLibrary : MonoBehaviour {
    private static AttackLibrary activeLibrary;
    private GameObject particlePanel;

    public GameObject
        blow,
        chargeBlow,
        ofuda,
        amuret,
        oodama,
        ikaring,
        shibuki,
        ikari,
        burst;
	// Use this for initialization
	void Start () {
        activeLibrary = this;
        particlePanel = GameObject.Find("ParticlePanel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static AttackLibrary GetInstance
    {
        get { return activeLibrary; }
    }

    /// <summary>
    /// ヒット時の衝撃波パーティクルを生成する
    /// </summary>
    /// <param name="pos"></param>
    public void CreateHitBurst(Vector3 pos)
    {
        var burstObject = GameObject.Instantiate(burst) as GameObject;
        burstObject.transform.parent = particlePanel.transform;
        burstObject.transform.localPosition = pos;
    }
}
