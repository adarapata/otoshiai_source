using UnityEngine;
using System.Collections;

/// <summary>
/// 状態クラスの基盤クラス
/// </summary>
public class BaseState :IState {

    virtual public int name { get { return 4; } }

	/// <summary>
	/// この状態を持つオブジェクト
	/// </summary>
	protected BaseCharacter stateParent
	{
		get;
		set;
	}
	
	/// <summary>
	/// 初期化時の状態を持つオブジェクトを設定する
	/// </summary>
	/// <param name='baseCharacter'>
	/// Base Character.
	/// </param>
	public BaseState(BaseCharacter baseCharacter)
	{
		stateParent = baseCharacter;
	}
	
	virtual public int Update()
	{
        return 0;
	}
}