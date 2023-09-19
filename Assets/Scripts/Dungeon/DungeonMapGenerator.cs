using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMapGenerator : MonoBehaviour
{
    /// <summary>
    /// 制御パラメータ(設定可能)
    /// </summary>
    [SerializeField] int x_MAX = 40;    // MAP最大X
    [SerializeField] int y_MAX = 40;    // MAP最大Y
    [SerializeField] int x_RECT_MIN = 7;     // 部屋の最小X = 4
    [SerializeField] int y_RECT_MIN = 7;     // 部屋の最小Y = 4
    [SerializeField] int x_LOAD_MAX = 2;     // 部屋と接続するX通路最大数
    [SerializeField] int y_LOAD_MAX = 2;     // 部屋と接続するY通路最大数
    [SerializeField] int floor_MAX = 6;      // 最大部屋数
    [SerializeField] int floor_PADDING = 2;  // 壁との余白
    /// <summary>MAP最大X</summary>
    static int X_MAX;
    /// <summary>MAP最大Y</summary>
    static int Y_MAX;
    /// <summary>
    /// 部屋のX軸の最小値の設定
    /// 部屋の最小X = 4
    /// </summary>
    static int X_RECT_MIN;
    /// <summary>
    /// 部屋のY軸の最小値の設定
    /// 部屋の最小Y = 4
    /// </summary>
    static int Y_RECT_MIN;
    /// <summary>
    /// 部屋と接続するX通路最大数
    /// 奇数は失敗しやすい
    /// </summary>
    static int X_LOAD_MAX;
    /// <summary>
    /// 部屋と接続するY通路最大数
    /// 奇数は失敗しやすい
    /// </summary>
    static int Y_LOAD_MAX;
    /// <summary>最大部屋数</summary>
    static int FLOOR_MAX;
    /// <summary>壁との余白</summary>
    static int FLOOR_PADDING;
    [SerializeField] GameObject _floorTile = null;
    [SerializeField] GameObject _player = null;

    bool _playerSet = false;
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

    public void RemakeMap()
    {
        X_MAX = x_MAX;    // MAP最大X
        Y_MAX = y_MAX;    // MAP最大Y
        X_RECT_MIN = x_RECT_MIN;    // 部屋の最小X = 4
        Y_RECT_MIN = y_RECT_MIN;    // 部屋の最小Y = 4
        X_LOAD_MAX = x_LOAD_MAX;    // 部屋と接続するX通路最大数
        Y_LOAD_MAX = y_LOAD_MAX;    // 部屋と接続するY通路最大数
        FLOOR_MAX = floor_MAX;  // 最大部屋数
        FLOOR_PADDING = floor_PADDING;  // 壁との余白
        mapData = new TYPE[X_MAX, Y_MAX];
    }

    /// <summary>
    /// 区域クラス
    /// </summary>
    public class Rect
    {
        public int _r_sx, _r_sy, _r_ex, _r_ey;     // 区域の開始,終了座標
        public int r_X, r_Y;                       // 区域のX,Y幅
        public int f_sx, f_sy, f_ex, f_ey;         // 部屋の開始,終了座標
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="r_sx">区域の開始x座標</param>
        /// <param name="r_sy">区域の開始y座標</param>
        /// <param name="r_ex">区域の終了x座標</param>
        /// <param name="r_ey">区域の終了y座標</param>
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
            // 区域幅を計算する
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

        for(int y = 0; y < mapData.GetLength(0); y++)
        {
            for(int x = 0; x < mapData.GetLength(1); x++)   // x軸の配置
            {
                if(mapData[y, x] == TYPE.FLOOR || mapData[y, x] == TYPE.LOAD_UP || mapData[y, x] == TYPE.LOAD_DOWN || mapData[y, x] == TYPE.LOAD_RIGHT || mapData[y, x] == TYPE.LOAD_LEFT)
                {
                    //Instantiate(_floorTile,new Vector2(x,y), this.transform.rotation);
                    if (!_playerSet && mapData[y, x] == TYPE.FLOOR)
                    {
                        Instantiate(_player, new Vector2(x, y), this.transform.rotation);
                        _playerSet = true;
                    }
                }
                else
                {
                    Instantiate(_floorTile, new Vector2(x, y), this.transform.rotation);
                }
            }
        }
    }

    /// <summary>
    /// 区域分割
    /// </summary>
    /// <param name="rectData">区域データ</param>
    private static void MakeRectData(List<Rect> rectData)
    {
        // 区域分割
        System.Random r;
        int target = 0;
        int rect_type = 0;
        int end_flg = 0;
        int seed = 0;
        // 全体区域の作成
        rectData.Add(new Rect(0, 0, X_MAX - 1, Y_MAX - 1));
        // 区域分割ループ
        while (true)
        {
            r = new System.Random(seed++);
            // 縦分割
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
            // 横分割
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
            // 分割終了
            if ((rectData.Count >= FLOOR_MAX) || (end_flg >= 2))
            {
                break;
            }
            // 面積が1番広い部屋を次の分割対象にする
            int max = 0;
            for (int i = 0; i < rectData.Count; i++)
            {
                int size = rectData[i].r_X * rectData[i].r_Y;
                if (max < size)
                {
                    max = size;
                    target = i;
                    // 縦or横分割どちらか判定する
                    if (rectData[i].r_X > rectData[i].r_Y)
                    {
                        // 縦分割
                        rect_type = 0;
                    }
                    else
                    {
                        // 横分割
                        rect_type = 1;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 部屋の作成
    /// </summary>
    /// <param name="rectData"></param>
    /// <param name="mapData"></param>
    private static void MakeFloorData(List<Rect> rectData, TYPE[,] mapData)
    {
        System.Random r;
        int seed = 0;
        // 区域毎に部屋頂点を作成する
        foreach (Rect rect in rectData)
        {
            int length_x = rect.r_X - 3;
            int length_y = rect.r_Y - 3;
            int expire = 0;
            int expire_1, expire_2;
            r = new System.Random(System.DateTime.Now.Millisecond + (++seed));
            expire = (length_x > length_y) ? r.Next(0, length_x - 4) : r.Next(0, length_y - 4);
            // 減少分をどちらから分配するか乱数にする
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
            // 部屋を設定する
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
    /// 通路作成
    /// </summary>
    /// <param name="rectData"></param>
    /// <param name="mapData"></param>
    private static void MakeLoadData(List<Rect> rectData, TYPE[,] mapData)
    {
        System.Random r;
        int seed = 0;
        // 部屋から区域に向けて線を伸ばす
        foreach (Rect tmp in rectData)
        {
            int load_x = 0, load_y = 0;
            int load_x_num = 0, load_y_num = 0;
            // 上方向
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
            // 下方向
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
            // 左方向
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
            // 右方向
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

        // 通路と通路を結ぶ
        foreach (Rect tmp in rectData)
        {
            // X方向の精査(下側境界)
            if (tmp.r_ey != Y_MAX - 1)
            {
                int start_x = -1;
                int end_x = -1;
                int count_x1 = 0, count_x2 = 0;
                for (int x = tmp.r_sx; x < tmp.r_ex; x++)
                {
                    // 上もしくは下に通路があれば処理開始
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
            // Y方向の精査(右側境界)
            if (tmp.r_ex != X_MAX - 1)
            {
                int start_y = -1;
                int end_y = -1;
                int count_y1 = 0, count_y2 = 0;
                for (int y = tmp.r_sy; y < tmp.r_ey; y++)
                {
                    // 左もしくは右に通路があれば処理開始
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

            // 行き止まりの場合、伸ばした先に通路があれば伸ばす
            for (int y = 0; y < Y_MAX; y++)
            {
                for (int x = 0; x < X_MAX; x++)
                {
                    // 左右方向に道がない
                    if (mapData[x, y] == TYPE.LOAD_LEFT_ALONE)
                    {
                        int flg = 0;
                        // 左に伸ばしてみる
                        for (int x2 = x - 1; x2 > 0; x2--)
                        {
                            if (mapData[x2, y] == TYPE.LOAD_LEFT || mapData[x2, y] == TYPE.LOAD_RIGHT)
                            {
                                // そこまでを通路に変える
                                for (int x3 = x2; x3 < x; x3++)
                                    mapData[x3, y] = TYPE.LOAD_LEFT_ALONE;
                                flg = 1;
                                x2 = 0;
                                break;
                            }
                        }
                        if (flg == 1)
                            continue;

                        // 右に伸ばしてみる
                        for (int x2 = x + 1; x2 < X_MAX; x2++)
                        {
                            if (mapData[x2, y] == TYPE.LOAD_LEFT || mapData[x2, y] == TYPE.LOAD_RIGHT)
                            {
                                // そこまでを通路に変える
                                for (int x3 = x; x3 < x2; x3++)
                                    mapData[x3, y] = TYPE.LOAD_LEFT_ALONE;
                                x2 = X_MAX;
                                break;
                            }
                        }
                    }
                    // 上下方向に道がない
                    if (mapData[x, y] == TYPE.LOAD_UP_ALONE)
                    {
                        int flg = 0;
                        // 上に伸ばしてみる
                        for (int y2 = y - 1; y2 > 0; y2--)
                        {
                            if (mapData[x, y2] == TYPE.LOAD_UP || mapData[x, y2] == TYPE.LOAD_DOWN)
                            {
                                // そこまでを通路に変える
                                for (int y3 = y2; y3 < y; y3++)
                                    mapData[x, y3] = TYPE.LOAD_UP_ALONE;
                                flg = 1;
                                y2 = 0;
                                break;
                            }
                        }
                        if (flg == 1)
                            continue;

                        // 右に伸ばしてみる
                        for (int y2 = y + 1; y2 < Y_MAX; y2++)
                        {
                            if (mapData[x, y2] == TYPE.LOAD_UP || mapData[x, y2] == TYPE.LOAD_DOWN)
                            {
                                // そこまでを通路に変える
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
