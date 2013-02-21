using UnityEngine;
using System.Collections;

/// <summary>
/// すべての状態のインタフェース
/// </summary>
public interface IState {
	/// <summary>
	/// 状態の更新
	/// </summary>
	int Update();
}