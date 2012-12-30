using UnityEngine;
using System.Collections;

public class MapChipParameter {

    public MapChipHP hp
    {
        get;
        set;
    }

    public MapPosition position
    {
        get;
        private set;
    }

    public int X
    {
        get { return position.X; }
    }

    public int Y
    {
        get { return position.Y; }
    }

    public MapChipParameter()
    {
        
    }
}

public class MapChipHP {

    public float strength
    {
        get;
        set;
    }

    public float autoDeduct
    {
        get;
        set;
    }
}

/// <summary>
/// �}�b�v�`�b�v��̍��W��ێ�����N���X
/// </summary>
public class MapPosition {

    /// <summary>
    /// �}�b�v�̒�`���܂Ƃ߂��N���X
    /// </summary>
    public class MapData
    {
        public const int MAX_X = 25;
        public const int MAX_Y = 14;
        public const int TOP = 300;
        public const int LEFT = -400;
        public const int RIGHT = 400;
        public const int BOTTUM = -172;
        public const int CHIP_WIDTH = 32;
        public const int CHIP_HEIGHT = 32;
        public const int ERROR_CODE = -1;

        public static int CaluclatePositionX(float x)
        {
            return CheckMapPosition(x, LEFT, RIGHT, CHIP_WIDTH, MAX_X);
        }

        public static int CaluclatePositionY(float y)
        {
            return CheckMapPosition(y, BOTTUM, TOP, CHIP_HEIGHT, MAX_Y);
        }

        private static int CheckMapPosition(float val, int min, int max, int size, int length)
        {
            if (val < min | val > max) { return ERROR_CODE; }

            for (int i = 0; i < length; i++)
            {
                if (val < min + (size * (i + 1))) return i;
            }

            return ERROR_CODE;
        }
    }

    public int X
    {
        get;
        set;
    }

    public int Y
    {
        get;
        set;
    }

    /// <summary>
    /// �X�N���[�����W����}�b�v���W��ݒ肷��
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public bool SetChipPositionByScreenPosition(Vector3 pos)
    {
        X = MapData.CaluclatePositionX(pos.x);
        if (X == MapData.ERROR_CODE) return false;

        Y = MapData.CaluclatePositionY(pos.y);
        if (Y == MapData.ERROR_CODE) return false;

        return true;
    }
}

