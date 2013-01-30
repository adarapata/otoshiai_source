using UnityEngine;
using System.Collections;

/// <summary>
/// ゲーム中のオブジェクトの基盤クラス
/// </summary>
public class BaseCharacter : MonoBehaviour {
	
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
        sprite = GetComponent<UISprite>();
		state = new BaseState(this);
		baseParameter = new BaseParameter(sprite);
	}
	
	// Update is called once per frame
	void Update () {
		state.Update();
	}

    /// <summary>
    /// 同じチームかどうかを返す
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    protected bool IsCheckSameTeam(Collider other)
    {
        return transform.parent.Equals(other.gameObject.transform.parent);
    }

    public void SetTeamTransform(Team _team, Transform parent)
    {
        baseParameter.team = _team;
        transform.parent = parent;
        transform.localScale = Vector3.one;
    }

    /// <summary>
    /// 画面外にいるかチェック。いたら自分を消去
    /// </summary>
    protected void CheckOutLine()
    {
        if (transform.localPosition.x < -600 || transform.localPosition.x > 600
            || transform.localPosition.y < -500 || transform.localPosition.y > 500)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 自身を削除する。オーバーライド可
    /// </summary>
    virtual protected void SelfDestroy()
    {
        Destroy(gameObject);
    }
}

