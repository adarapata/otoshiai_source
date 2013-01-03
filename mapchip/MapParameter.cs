using UnityEngine;
using System.Collections;


/// <summary>
/// マップ情報を格納したクラス
/// </summary>
public class MapParameter
{
    /// <summary>
    /// プレイヤーの最大数
    /// </summary>
    private const int PLAYER_MAX = 4;
    /// <summary>
    /// ステージファイル
    /// </summary>
    private TextAsset resource;
    /// <summary>
    /// キャラの初期位置
    /// </summary>
    private MapPosition[] playersFirstPosition;
    /// <summary>
    /// マップのチップ情報
    /// </summary>
    private int[,] mapDataList;

    public MapParameter(string fileName)
    {
        resource = Resources.Load(fileName) as TextAsset;
        string allString = resource.text;
        string[] splitByLine = allString.Split('\n');

        playersFirstPosition = new MapPosition[PLAYER_MAX];

        SetFirstPositions(splitByLine);

        string[] mapArray = CreateMapArray(splitByLine);

        mapDataList = CreateMapdata(mapArray);
    }

    public MapPosition GetFirstPosition(int playerNumber)
    {
        if (playerNumber > PLAYER_MAX) return null;

        return playersFirstPosition[playerNumber];
    }

    public int GetMapChipNumber(int x, int y)
    {
        return mapDataList[x, y];
    }

    /// <summary>
    /// 各キャラの初期位置データを設定
    /// </summary>
    /// <param name="splitByLine"></param>
    private void SetFirstPositions(string[] splitByLine)
    {
        for (int i = 0; i < PLAYER_MAX; i++)
        {
            string[] playerPosition = splitByLine[i].Split(',');
            int x = int.Parse(playerPosition[0]);
            int y = int.Parse(playerPosition[1]);
            playersFirstPosition[i] = new MapPosition(x, y);
        }
    }

    /// <summary>
    /// マップ配列を作成
    /// </summary>
    /// <param name="splitByLine"></param>
    /// <returns></returns>
    private string[] CreateMapArray(string[] splitByLine)
    {
        string[] mapArray = new string[splitByLine.Length - PLAYER_MAX];
        for (int i = 0; i < mapArray.Length; i++)
        {
            mapArray[i] = splitByLine[i + PLAYER_MAX];
        }

        return mapArray;
    }

    /// <summary>
    /// 実際のマップデータを作成
    /// </summary>
    /// <param name="mapArray"></param>
    /// <returns></returns>
    private int[,] CreateMapdata(string[] mapArray)
    {
        mapDataList = new int[MapPosition.MapData.MAX_X, MapPosition.MapData.MAX_Y];
        for (int i = 0; i < mapArray.Length; i++)
        {
            string[] x_array = mapArray[i].Split(',');
            for (int j = 0; j < x_array.Length; j++)
            {
                mapDataList[j, i] = int.Parse(x_array[j]);
            }
        }
        return mapDataList;
    }
}

