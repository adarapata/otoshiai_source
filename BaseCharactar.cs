using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム中のオブジェクトの基盤クラス
/// </summary>
public class BaseCharactar : MonoBehaviour {
	
	public UISprite sprite;
	/// <summary>
	/// 状態　　　get;set;
	/// </summary>
	/// <value>
	/// The state.
	/// </value>
	public IState state {
		get;
		set;
	}
	
	public IAnimationController animation
	{
		get;
		set;
	}
	
	/// <summary>
	/// オブジェクトの基本パラメータ  get;set;
	/// </summary>
	/// <value>
	/// The base parameter.
	/// </value>
	public BaseParameter baseParameter {
		get;
		set;
	}
	

	// Use this for initialization
	void Start () {
		state = new BaseState(this);
		baseParameter = new BaseParameter();
		sprite = GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
		state.Update();
	}
}

