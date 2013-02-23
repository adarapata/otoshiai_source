using UnityEngine;
using System.Collections;

/// <summary>
/// すべての状態のインタフェース
/// </summary>
public interface IState {
    /// <summary>
    /// 状態番号。それぞれの列挙体をキャストして使うので数値は気にする必要はない
    /// </summary>
    int name { get; }

	/// <summary>
	/// 状態の更新
	/// </summary>
	int Update();
}