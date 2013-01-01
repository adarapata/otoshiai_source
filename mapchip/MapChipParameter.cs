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

        /// <summary>
        /// �X�N���[�����W����}�b�v���W��Ԃ�
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int CaluclatePositionX(float x)
        {
            return CheckMapPosition(x, LEFT, RIGHT, CHIP_WIDTH, MAX_X);
        }

        /// <summary>
        /// �X�N���[�����W����}�b�v���W��Ԃ�
        /// </summary>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CaluclatePositionY(float y)
        {
            var val = CheckMapPosition(y, BOTTUM, TOP, CHIP_HEIGHT, MAX_Y);
            //�㉺���]���Ă���̂ŁA�X�N���[���オ0�ɂȂ�悤�ɕϊ�����
            return val == ERROR_CODE ? ERROR_CODE : Mathf.Abs(MAX_Y - 1 - val);
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
        /// �}�b�v���W����X�N���[�����W��Ԃ�
        /// </summary>
        /// <param name="mapPositionX"></param>
        /// <returns></returns>
        public static float CaluclateScreenPositionX(int mapPositionX)
        {
            return ConvertMapPositionToScreen(mapPositionX, LEFT, CHIP_WIDTH);
        }
        /// <summary>
        /// �}�b�v���W����X�N���[�����W��Ԃ�
        /// </summary>
        /// <param name="mapPositionY"></param>
        /// <returns></returns>
        public static float CaluclateScreenPositionY(int mapPositionY)
        {
            //�㉺���]���Ă���̂ŁA�}�b�v���W�𔽓]������
            mapPositionY = Mathf.Abs(MAX_Y - 1 - mapPositionY);
            return ConvertMapPositionToScreen(mapPositionY, BOTTUM, CHIP_HEIGHT);
        }

        /// <summary>
        /// �}�b�v���W�����ɃX�N���[�����W��Ԃ�
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static float ConvertMapPositionToScreen(int val, int min, int size)
        {
            return (min + size * val) + size / 2;
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

    /// <summary>
    /// �R���X�g���N�^�ŃX�N���[�����W��ݒ肷��
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="localPosition"></param>
    public MapPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// �����̃}�b�v���W�����ɃX�N���[�����W��Ԃ�
    /// </summary>
    /// <returns>�}�b�v�͈͊O�ɏo�Ă�����false���Ԃ�</returns>
    public Vector2 GetScreenPositionByMapPosition()
    {
        float x = MapData.CaluclateScreenPositionX(X);
        float y = MapData.CaluclateScreenPositionY(Y);
        return new Vector2(x, y);
    }
}

