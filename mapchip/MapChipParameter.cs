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
/// マップチップ上の座標を保持するクラス
/// </summary>
public class MapPosition {

    /// <summary>
    /// マップの定義をまとめたクラス
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

        /// <summary>
        /// スクリーン座標からマップ座標を返す
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int CaluclatePositionX(float x)
        {
            return CheckMapPosition(x, LEFT, RIGHT, CHIP_WIDTH, MAX_X);
        }

        /// <summary>
        /// スクリーン座標からマップ座標を返す
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
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

        /// <summary>
        /// マップ座標からスクリーン座標を返す
        /// </summary>
        /// <param name="mapPositionX"></param>
        /// <returns></returns>
        public static float CaluclateScreenPositionX(int mapPositionX)
        {
            return ConvertMapPositionToScreen(mapPositionX, LEFT, CHIP_WIDTH);
        }
        /// <summary>
        /// マップ座標からスクリーン座標を返す
        /// </summary>
        /// <param name="mapPositionY"></param>
        /// <returns></returns>
        public static float CaluclateScreenPositionY(int mapPositionY)
        {
            return ConvertMapPositionToScreen(mapPositionY, BOTTUM, CHIP_HEIGHT);
        }

        /// <summary>
        /// マップ座標を元にスクリーン座標を返す
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static float ConvertMapPositionToScreen(int val, int min, int size)
        {
            return min + size * val;
        }
    }

    public int X
    {
        get;
        private set;
    }

    public int Y
    {
        get;
        private set;
    }

    /// <summary>
    /// スクリーン座標からマップ座標を設定する
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

