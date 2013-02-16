using UnityEngine;
using System.Collections;

public class CharacterSelectForm : MonoBehaviour {
    
    const int MAXLINE = 7;
    int line = 0;

    void Awake()
    {
 
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { Up(); }
        if (Input.GetKeyDown(KeyCode.DownArrow)) { Down(); }
	}

    private void Up()
    {
        if (line <= 0) return;
        transform.localPosition -= new Vector3(0, 128F*transform.localScale.y, 0);
        line--;
    }

    private void Down()
    {
        if (line >= MAXLINE - 1) return;
        transform.localPosition += new Vector3(0, 128F*transform.localScale.y, 0);
        line++;
    }
}
