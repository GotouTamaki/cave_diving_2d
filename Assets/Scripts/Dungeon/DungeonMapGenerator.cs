using System.Collections.Generic;
using UnityEngine;

public class DungeonMapGenerator : MonoBehaviour
{
    /// <summary>
    /// ����p�����[�^(�ݒ�\)
    /// </summary>
    [SerializeField] int x_MAX = 40;    // MAP�ő�X
    [SerializeField] int y_MAX = 40;    // MAP�ő�Y
    [SerializeField] int x_RECT_MIN = 7;     // �����̍ŏ�X = 4
    [SerializeField] int y_RECT_MIN = 7;     // �����̍ŏ�Y = 4
    [SerializeField] int x_LOAD_MAX = 2;     // �����Ɛڑ�����X�ʘH�ő吔
    [SerializeField] int y_LOAD_MAX = 2;     // �����Ɛڑ�����Y�ʘH�ő吔
    [SerializeField] int floor_MAX = 6;      // �ő啔����
    [SerializeField] int floor_PADDING = 2;  // �ǂƂ̗]��
    /// <summary>�}�b�v�^�C���̐ݒ�</summary>
    [SerializeField] GameObject _mapTile = null;
    /// <summary>�v���C���[�̐ݒ�</summary>
    [SerializeField] GameObject _player = null;
    /// <summary>HP�\���̐ݒ�</summary>
    [SerializeField] HPUI _hpText = null;
    /// <summary>���̐ݒ�</summary>
    [SerializeField] GameObject _floorBlock = null;
    /// <summary>�G�̐ݒ�</summary>
    [SerializeField] GameObject[] _enemy = null;
    /// <summary>�A�C�e���̐ݒ�</summary>
    [SerializeField] GameObject[] _item = null;
    /// <summary>�A�C�e���̔z�u������</summary>
    [SerializeField] int _itemCountLimit = 40;

    /// <summary>MAP�ő�X</summary>
    static int X_MAX;
    /// <summary>MAP�ő�Y</summary>
    static int Y_MAX;
    /// <summary>
    /// ������X���̍ŏ��l�̐ݒ�
    /// �����̍ŏ�X = 4
    /// </summary>
    static int X_RECT_MIN;
    /// <summary>
    /// ������Y���̍ŏ��l�̐ݒ�
    /// �����̍ŏ�Y = 4
    /// </summary>
    static int Y_RECT_MIN;
    /// <summary>
    /// �����Ɛڑ�����X�ʘH�ő吔
    /// ��͎��s���₷��
    /// </summary>
    static int X_LOAD_MAX;
    /// <summary>
    /// �����Ɛڑ�����Y�ʘH�ő吔
    /// ��͎��s���₷��
    /// </summary>
    static int Y_LOAD_MAX;
    /// <summary>�ő啔����</summary>
    static int FLOOR_MAX;
    /// <summary>�ǂƂ̗]��</summary>
    static int FLOOR_PADDING;
    /// <summary>�v���C���[��z�u���鎞�̃t���O</summary>
    bool _playerSet = false;
    /// <summary>�A�C�e���̔z�u��</summary>
    int _itemCount = 0;

    public enum TYPE
    {
        NONE, WALL, FLOOR,
        LOAD_UP, LOAD_DOWN, LOAD_RIGHT, LOAD_LEFT,
        LOAD_UP_ALONE, LOAD_LEFT_ALONE,
        ETC1, ETC2, ETC3, ETC4, ETC5,
    }
    public TYPE[,] mapData;

    private List<Rect> rectData = new List<Rect>();

    private void OnEnable()
    {
        RemakeMap();
    }

    /// <summary>�}�b�v�ݒ�̍Đݒ�</summary>
    public void RemakeMap()
    {
        X_MAX = x_MAX;    // MAP�ő�X
        Y_MAX = y_MAX;    // MAP�ő�Y
        X_RECT_MIN = x_RECT_MIN;    // �����̍ŏ�X = 4
        Y_RECT_MIN = y_RECT_MIN;    // �����̍ŏ�Y = 4
        X_LOAD_MAX = x_LOAD_MAX;    // �����Ɛڑ�����X�ʘH�ő吔
        Y_LOAD_MAX = y_LOAD_MAX;    // �����Ɛڑ�����Y�ʘH�ő吔
        FLOOR_MAX = floor_MAX;  // �ő啔����
        FLOOR_PADDING = floor_PADDING;  // �ǂƂ̗]��
        mapData = new TYPE[X_MAX, Y_MAX];   //�}�b�v�f�[�^
    }

    /// <summary>
    /// ���N���X
    /// </summary>
    public class Rect
    {
        public int _r_sx, _r_sy, _r_ex, _r_ey;     // ���̊J�n,�I�����W
        public int r_X, r_Y;                       // ����X,Y��
        public int f_sx, f_sy, f_ex, f_ey;         // �����̊J�n,�I�����W
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="r_sx">���̊J�nx���W</param>
        /// <param name="r_sy">���̊J�ny���W</param>
        /// <param name="r_ex">���̏I��x���W</param>
        /// <param name="r_ey">���̏I��y���W</param>
        public Rect(int r_sx, int r_sy, int r_ex, int r_ey)
        {
            this._r_sx = r_sx;
            this._r_sy = r_sy;
            this._r_ex = r_ex;
            this._r_ey = r_ey;
            this.f_sx = r_sx + FLOOR_PADDING;
            this.f_sy = r_sy + FLOOR_PADDING;
            this.f_ex = r_ex - FLOOR_PADDING;
            this.f_ey = r_ey - FLOOR_PADDING;
            // ��敝���v�Z����
            this.r_X = r_ex - r_sx;
            this.r_Y = r_ey - r_sy;
        }
        public int r_sx
        {
            get { return _r_sx; }
            set
            {
                _r_sx = value;
                f_sx = value + FLOOR_PADDING;
                r_X = _r_ex - _r_sx;
            }
        }
        public int r_sy
        {
            get { return _r_sy; }
            set
            {
                _r_sy = value;
                f_sy = value + FLOOR_PADDING;
                r_Y = _r_ey - _r_sy;
            }
        }
        public int r_ex
        {
            get { return _r_ex; }
            set
            {
                _r_ex = value;
                f_ex = value - FLOOR_PADDING;
                r_X = _r_ex - _r_sx;
            }
        }
        public int r_ey
        {
            get { return _r_ey; }
            set
            {
                _r_ey = value;
                f_ey = value - FLOOR_PADDING;
                r_Y = _r_ey - _r_sy;
            }
        }
    }

    public void Start()
    {
        MakeRectData(rectData);
        MakeFloorData(rectData, mapData);
        MakeLoadData(rectData, mapData);

        for (int y = 0; y < mapData.GetLength(0); y++)
        {
            for (int x = 0; x < mapData.GetLength(1); x++)   // x���̔z�u
            {
                if (mapData[y, x] == TYPE.FLOOR || mapData[y, x] == TYPE.LOAD_UP || mapData[y, x] == TYPE.LOAD_DOWN || mapData[y, x] == TYPE.LOAD_RIGHT || mapData[y, x] == TYPE.LOAD_LEFT)
                {
                    // �v���C���[�̐���
                    if (!_playerSet && mapData[y, x] == TYPE.FLOOR)
                    {
                        Instantiate(_player, new Vector2(x, y), this.transform.rotation);
                        _hpText.PlayerHPDisplaySet();
                        _playerSet = true;
                    }

                    switch (Random.Range(0, 100))
                    {
                        // ���̐���
                        case 0:
                            if (mapData[y, x] == TYPE.FLOOR)
                            {
                                Instantiate(_floorBlock, new Vector2(x, y), this.transform.rotation);
                            }
                            break;
                        // �A�C�e���̐���
                        case 1:
                            if (_itemCount < _itemCountLimit)
                            {
                                Instantiate(_item[Random.Range(0, _item.Length)], new Vector2(x, y), this.transform.rotation);
                                _itemCount++;
                            }
                            break;
                        // �G�̐���
                        case 2:
                            Instantiate(_enemy[Random.Range(0, _enemy.Length)], new Vector2(x, y), this.transform.rotation);
                            break;
                    }
                }
                else
                {
                    // �}�b�v�̐���
                    Instantiate(_mapTile, new Vector2(x, y), this.transform.rotation);
                }
            }
        }
    }

    /// <summary>
    /// ��敪��
    /// </summary>
    /// <param name="rectData">���f�[�^</param>
    private static void MakeRectData(List<Rect> rectData)
    {
        // ��敪��
        System.Random r;
        int target = 0;
        int rect_type = 0;
        int end_flg = 0;
        int seed = 0;
        // �S�̋��̍쐬
        rectData.Add(new Rect(0, 0, X_MAX - 1, Y_MAX - 1));
        // ��敪�����[�v
        while (true)
        {
            r = new System.Random(seed++);
            // �c����
            if (rect_type == 0)
            {
                if (rectData[target].r_sx + X_RECT_MIN < rectData[target].r_ex - X_RECT_MIN)
                {
                    int c_x = r.Next(rectData[target].r_sx + X_RECT_MIN, rectData[target].r_ex - X_RECT_MIN);
                    rectData.Add(new Rect(c_x + 1, rectData[target].r_sy, rectData[target].r_ex, rectData[target].r_ey));
                    rectData[target].r_ex = c_x;
                }
                else
                {
                    end_flg++;
                }
            }
            // ������
            else
            {
                if (rectData[target].r_sy + Y_RECT_MIN < rectData[target].r_ey - Y_RECT_MIN)
                {
                    int c_y = r.Next(rectData[target].r_sy + Y_RECT_MIN, rectData[target].r_ey - Y_RECT_MIN);
                    rectData.Add(new Rect(rectData[target].r_sx, c_y + 1, rectData[target].r_ex, rectData[target].r_ey));
                    rectData[target].r_ey = c_y;
                }
                else
                {
                    end_flg++;
                }
            }
            // �����I��
            if ((rectData.Count >= FLOOR_MAX) || (end_flg >= 2))
            {
                break;
            }
            // �ʐς�1�ԍL�����������̕����Ώۂɂ���
            int max = 0;
            for (int i = 0; i < rectData.Count; i++)
            {
                int size = rectData[i].r_X * rectData[i].r_Y;
                if (max < size)
                {
                    max = size;
                    target = i;
                    // �cor�������ǂ��炩���肷��
                    if (rectData[i].r_X > rectData[i].r_Y)
                    {
                        // �c����
                        rect_type = 0;
                    }
                    else
                    {
                        // ������
                        rect_type = 1;
                    }
                }
            }
        }
    }

    /// <summary>
    /// �����̍쐬
    /// </summary>
    /// <param name="rectData"></param>
    /// <param name="mapData"></param>
    private static void MakeFloorData(List<Rect> rectData, TYPE[,] mapData)
    {
        System.Random r;
        int seed = 0;
        // ��斈�ɕ������_���쐬����
        foreach (Rect rect in rectData)
        {
            int length_x = rect.r_X - 3;
            int length_y = rect.r_Y - 3;
            int expire = 0;
            int expire_1, expire_2;
            r = new System.Random(System.DateTime.Now.Millisecond + (++seed));
            expire = (length_x > length_y) ? r.Next(0, length_x - 4) : r.Next(0, length_y - 4);
            // ���������ǂ��炩�番�z���邩�����ɂ���
            expire_1 = expire - r.Next(0, expire);
            expire_2 = expire - expire_1;

            if (length_x > length_y)
            {
                rect.f_sx += expire_1;
                rect.f_ex -= expire_2;
            }
            else
            {
                rect.f_sy += expire_1;
                rect.f_ey -= expire_2;
            }
            // ������ݒ肷��
            for (int y = rect.f_sy; y <= rect.f_ey; y++)
            {
                for (int x = rect.f_sx; x <= rect.f_ex; x++)
                {
                    mapData[x, y] = TYPE.FLOOR;
                }
            }
        }
    }

    /// <summary>
    /// �ʘH�쐬
    /// </summary>
    /// <param name="rectData"></param>
    /// <param name="mapData"></param>
    private static void MakeLoadData(List<Rect> rectData, TYPE[,] mapData)
    {
        System.Random r;
        int seed = 0;
        // ����������Ɍ����Đ���L�΂�
        foreach (Rect tmp in rectData)
        {
            int load_x = 0, load_y = 0;
            int load_x_num = 0, load_y_num = 0;
            // �����
            load_x = tmp.f_sx + 1;
            load_x_num = 0;
            while ((load_x < (tmp.f_ex - 1)) && (load_x_num < X_LOAD_MAX) && (tmp.r_sy != 0))
            {
                r = new System.Random(seed++);
                load_x = r.Next(load_x, tmp.f_ex - 1);
                load_x_num++;
                for (int y = tmp.r_sy; y < tmp.f_sy; y++)
                    mapData[load_x, y] = TYPE.LOAD_UP;
                load_x += 2;
            }
            // ������
            load_x = tmp.f_sx + 1;
            load_x_num = 0;
            while ((load_x < (tmp.f_ex - 1)) && (load_x_num < X_LOAD_MAX) && (tmp.r_ey != Y_MAX - 1))
            {
                r = new System.Random(seed++);
                load_x = r.Next(load_x, tmp.f_ex - 1);
                load_x_num++;
                for (int y = tmp.f_ey + 1; y < tmp.r_ey; y++)
                    mapData[load_x, y] = TYPE.LOAD_DOWN;
                load_x += 2;
            }
            // ������
            load_y = tmp.f_sy + 1;
            load_y_num = 0;
            while ((load_y < (tmp.f_ey - 1)) && (load_y_num < Y_LOAD_MAX) && (tmp.r_sx != 0))
            {
                r = new System.Random(seed++);
                load_y = r.Next(load_y, tmp.f_ey - 1);
                load_y_num++;
                for (int x = tmp.r_sx; x < tmp.f_sx; x++)
                    mapData[x, load_y] = TYPE.LOAD_LEFT;
                load_y += 2;
            }
            // �E����
            load_y = tmp.f_sy + 1;
            load_y_num = 0;
            while ((load_y < (tmp.f_ey - 1)) && (load_y_num < Y_LOAD_MAX) && (tmp.r_ex != X_MAX - 1))
            {
                r = new System.Random(seed++);
                load_y = r.Next(load_y, tmp.f_ey - 1);
                load_y_num++;
                for (int x = tmp.f_ex + 1; x < tmp.r_ex; x++)
                    mapData[x, load_y] = TYPE.LOAD_RIGHT;
                load_y += 2;
            }
        }

        // �ʘH�ƒʘH������
        foreach (Rect tmp in rectData)
        {
            // X�����̐���(�������E)
            if (tmp.r_ey != Y_MAX - 1)
            {
                int start_x = -1;
                int end_x = -1;
                int count_x1 = 0, count_x2 = 0;
                for (int x = tmp.r_sx; x < tmp.r_ex; x++)
                {
                    // ��������͉��ɒʘH������Ώ����J�n
                    if (mapData[x, tmp.r_ey - 1] == TYPE.LOAD_DOWN)
                    {
                        count_x1++;
                        end_x = x;
                    }
                    if (mapData[x, tmp.r_ey + 1] == TYPE.LOAD_UP)
                    {
                        count_x2++;
                        end_x = x;
                    }
                    if ((count_x1 > 0 || count_x2 > 0) && (start_x == -1))
                    {
                        start_x = x;
                    }
                }
                if (start_x != -1)
                {
                    if (count_x1 * count_x2 == 0)
                    {
                        mapData[start_x, tmp.r_ey] = TYPE.LOAD_LEFT_ALONE;
                    }
                    else
                    {
                        for (int x = start_x; x <= end_x; x++)
                            mapData[x, tmp.r_ey] = TYPE.LOAD_LEFT;
                    }
                }
            }
            // Y�����̐���(�E�����E)
            if (tmp.r_ex != X_MAX - 1)
            {
                int start_y = -1;
                int end_y = -1;
                int count_y1 = 0, count_y2 = 0;
                for (int y = tmp.r_sy; y < tmp.r_ey; y++)
                {
                    // ���������͉E�ɒʘH������Ώ����J�n
                    if (mapData[tmp.r_ex - 1, y] == TYPE.LOAD_RIGHT)
                    {
                        count_y1++;
                        end_y = y;
                    }
                    if (mapData[tmp.r_ex + 1, y] == TYPE.LOAD_LEFT)
                    {
                        count_y2++;
                        end_y = y;
                    }
                    if ((count_y1 > 0 || count_y2 > 0) && (start_y == -1))
                    {
                        start_y = y;
                    }
                }
                if (start_y != -1)
                {
                    if (count_y1 * count_y2 == 0)
                    {
                        mapData[tmp.r_ex, start_y] = TYPE.LOAD_UP_ALONE;
                    }
                    else
                    {
                        for (int y = start_y; y <= end_y; y++)
                            mapData[tmp.r_ex, y] = TYPE.LOAD_UP;
                    }
                }
            }

            // �s���~�܂�̏ꍇ�A�L�΂�����ɒʘH������ΐL�΂�
            for (int y = 0; y < Y_MAX; y++)
            {
                for (int x = 0; x < X_MAX; x++)
                {
                    // ���E�����ɓ����Ȃ�
                    if (mapData[x, y] == TYPE.LOAD_LEFT_ALONE)
                    {
                        int flg = 0;
                        // ���ɐL�΂��Ă݂�
                        for (int x2 = x - 1; x2 > 0; x2--)
                        {
                            if (mapData[x2, y] == TYPE.LOAD_LEFT || mapData[x2, y] == TYPE.LOAD_RIGHT)
                            {
                                // �����܂ł�ʘH�ɕς���
                                for (int x3 = x2; x3 < x; x3++)
                                    mapData[x3, y] = TYPE.LOAD_LEFT_ALONE;
                                flg = 1;
                                x2 = 0;
                                break;
                            }
                        }
                        if (flg == 1)
                            continue;

                        // �E�ɐL�΂��Ă݂�
                        for (int x2 = x + 1; x2 < X_MAX; x2++)
                        {
                            if (mapData[x2, y] == TYPE.LOAD_LEFT || mapData[x2, y] == TYPE.LOAD_RIGHT)
                            {
                                // �����܂ł�ʘH�ɕς���
                                for (int x3 = x; x3 < x2; x3++)
                                    mapData[x3, y] = TYPE.LOAD_LEFT_ALONE;
                                x2 = X_MAX;
                                break;
                            }
                        }
                    }
                    // �㉺�����ɓ����Ȃ�
                    if (mapData[x, y] == TYPE.LOAD_UP_ALONE)
                    {
                        int flg = 0;
                        // ��ɐL�΂��Ă݂�
                        for (int y2 = y - 1; y2 > 0; y2--)
                        {
                            if (mapData[x, y2] == TYPE.LOAD_UP || mapData[x, y2] == TYPE.LOAD_DOWN)
                            {
                                // �����܂ł�ʘH�ɕς���
                                for (int y3 = y2; y3 < y; y3++)
                                    mapData[x, y3] = TYPE.LOAD_UP_ALONE;
                                flg = 1;
                                y2 = 0;
                                break;
                            }
                        }
                        if (flg == 1)
                            continue;

                        // �E�ɐL�΂��Ă݂�
                        for (int y2 = y + 1; y2 < Y_MAX; y2++)
                        {
                            if (mapData[x, y2] == TYPE.LOAD_UP || mapData[x, y2] == TYPE.LOAD_DOWN)
                            {
                                // �����܂ł�ʘH�ɕς���
                                for (int y3 = y; y3 < y2; y3++)
                                    mapData[x, y3] = TYPE.LOAD_UP_ALONE;
                                y2 = Y_MAX;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
