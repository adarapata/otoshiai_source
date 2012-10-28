using UnityEngine;
using System.Collections;

/// <summary>
/// 状態クラスの基盤クラス
/// </summary>
public class BaseState :IState {
	/// <summary>
	/// この状態を持つオブジェクト
	/// </summary>
	protected BaseCharactar stateParent;
	
	/// <summary>
	/// 初期化時の状態を持つオブジェクトを設定する
	/// </summary>
	/// <param name='baseCharactar'>
	/// Base charactar.
	/// </param>
	public BaseState(BaseCharactar baseCharactar)
	{
		stateParent = baseCharactar;
	}
	
	virtual public void Update()
	{
		Debug.Log("base");
	}
}