using UnityEngine;
using System.Collections;

/// <summary>
/// �}�b�v�`�b�v���Ǘ�����N���X
/// </summary>
public class MapManager : MonoBehaviour {

    public GameObject template_chip;
    private MapChip[,] mapchips = new MapChip[MapPosition.MapData.MAX_X, MapPosition.MapData.MAX_Y];

	// Use this for initialization
	void Start () {
        int max_x = MapPosition.MapData.MAX_X;
        int max_y = MapPosition.MapData.MAX_Y;

        for (int i = 0; i < max_x; i++)
        {
            for (int j = 0; j < max_y; j++)
            {
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
    /// �w�肵�����W�̃}�b�v�`�b�v���擾����B
    /// ���݂��Ȃ��ꍇnull��Ԃ�
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public MapChip GetMapChip(MapPosition pos)
    {
        return mapchips[pos.X, pos.Y];
    }
}
