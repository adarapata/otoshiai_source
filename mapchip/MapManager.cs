using UnityEngine;
using System.Collections;

/// <summary>
/// マップチップを管理するクラス
/// </summary>
public class MapManager : MonoBehaviour {

    private const int NONE_CHIP = 0;
    public GameObject template_chip;
    private MapChip[,] mapchips = new MapChip[MapPosition.MapData.MAX_X, MapPosition.MapData.MAX_Y];
    public MapParameter mapParameter
    {
        get;
        set;
    }

	// Use this for initialization
	void Start () {

        mapParameter = new MapParameter("stage_ice");
        int max_x = MapPosition.MapData.MAX_X;
        int max_y = MapPosition.MapData.MAX_Y;

        for (int i = 0; i < max_x; i++)
        {
            for (int j = 0; j < max_y; j++)
            {
                int val = mapParameter.GetMapChipNumber(i, j);
                if (val == NONE_CHIP) { mapchips[i, j] = null; continue; }

                var chip = GameObject.Instantiate(template_chip) as GameObject;

                chip.transform.parent = transform;
                chip.transform.localScale = new Vector3(32F, 32F, 1F);
                chip.GetComponent<MapChip>().SetMapPosition(i, j);
                mapchips[i, j] = chip.GetComponent<MapChip>();
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    /// <summary>
    /// 指定した座標のマップチップを取得する。
    /// 存在しない場合nullを返す
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public MapChip GetMapChip(MapPosition pos)
    {
        return mapchips[pos.X, pos.Y];
    }
}
