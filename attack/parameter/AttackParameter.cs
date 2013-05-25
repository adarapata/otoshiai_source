using UnityEngine;
using System.Collections;

/// <summary>
/// 攻撃オブジェクトのパラメータ
/// </summary>
public class AttackParameter {
    /// <summary>
    /// ダメージ
    /// </summary>
    public Damage damage
    {
        get;
        set;
    }

    public AttackLevel attackLevel
    {
        get;
        set;
    }


}

/// <summary>
/// 攻撃レベルのクラス
/// </summary>
public class AttackLevel
{
    public const int MIN_LEVEL = 1;
    public const int MAX_LEVEL = 5;

    private int m_level;
    /// <summary>
    /// 攻撃レベル
    /// </summary>
    private int level
    {
        get { return m_level; }
        set
        {
            //バリデーションかけておく
            if (value < MIN_LEVEL) { m_level = MIN_LEVEL; return; }
            if (value > MAX_LEVEL) { m_level = MAX_LEVEL; return; }
            m_level = value;
        }
    }

    /// <summary>
    /// 同レベルの場合、敗北判定か
    /// </summary>
    private bool setOff
    {
        get;
        set;
    }

    public AttackLevel(int Level, bool SetOff)
    {
        level = Level;
        setOff = SetOff;
    }

    /// <summary>
    /// 相手のレベルと比較する
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    public bool CheckLevel(AttackLevel enemy)
    {
        int a = level - enemy.level;
        //相殺可の場合、自分のレベルを１下げて計算する
        if (setOff) a--;
        return a >= 0;
    }
}