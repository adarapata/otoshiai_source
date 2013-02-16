using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    public UISprite child;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        child.pivot = UIWidget.Pivot.Bottom;
        child.pivot = UIWidget.Pivot.Center;
	}

    /// <summary>
    /// 登場からアニメーション
    /// </summary>
    public void StartAnimation()
    {
        TweenPosition move = gameObject.AddComponent<TweenPosition>();
        move.from = transform.localPosition;
        move.to = new Vector3(transform.localPosition.x+16, 0, 0);
        move.duration = 1F;

        SpriteAnimation();
    }

    private void SpriteAnimation()
    {
        var anime = child.gameObject.GetComponent<UISpriteAnimation>();
        anime.enabled = true;
    }
}
