using UnityEngine;
using System.Collections;

namespace cs
{
    public class PlayerControl : MonoBehaviour
    {


        private Camera PlayerCam;           // Camera used by the player
        private GameManager _GameManager;   // GameObject responsible for the management of the game       

        static int LINENUM = 0;
        public static int curx = 0, cury = 0;
        public static int player = 0;
        public int mode = 0;
        public static string answer = "J";


        public static bool isPush = false;
        public static bool issteal = false;
        public GameObject floor01D;
        public GameObject floor02D;
        public GameObject blockS01D;
        public GameObject blockS02D;
        public GameObject blockSpike01D;
        public GameObject blockSpike02D;
        public GameObject Plane;
        public GameObject Pillar01Blue, Pillar01Red;
        public static Vector3 offset = new Vector3(0, 0, 0);
        public static Quaternion rotation = Quaternion.Euler(0, 90, 0);

        // Use this for initialization
        void DrawBoard()
        {
            Plate.init();
            Plate.floors = new GameObject[15][];
            for (int i = 0; i < 15; i++)
            {
                Plate.floors[i] = new GameObject[15];
            }

            for (int i = -1; i <= 15; ++i)
            {
                for (int j = -1; j <= 15; ++j)
                {
                    GameObject floor;

                    Vector3 position = offset + new Vector3(i * 2, 0f, j * 2);
                    if (i < 5 || i > 9) position += new Vector3(0f, 0.5f, 0);

                    if ((i + j) % 2 == 0)
                        floor = Instantiate(floor01D, position, rotation);
                    else
                        floor = Instantiate(floor02D, position, rotation);
                    floor.transform.parent = gameObject.transform;
                    if (i >= 0 && i < 15 && j >= 0 && j < 15)
                    {
                        floor.GetComponent<BoardSquare>().posx = i;
                        floor.GetComponent<BoardSquare>().posy = j;

                        GameObject newplane = Instantiate(Plane, position + new Vector3(0f, 1.5f, 0f), rotation);
                        newplane.SetActive(false);
                        newplane.transform.parent = floor.transform;
                        Plate.floors[i][j] = floor;
                    }
                    if (i == -1)
                    {
                        GameObject border, border2, border3;
                        if (j == -1)
                        {
                            border = Instantiate(blockSpike02D, position + new Vector3(-0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS02D, position + new Vector3(0.5f, 1.5f, -0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border = Instantiate(blockS01D, position + new Vector3(-0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                        }

                        if (j == 15)
                        {
                            border2 = Instantiate(blockSpike01D, position + new Vector3(-0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS01D, position + new Vector3(0.5f, 1.5f, 0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border2 = Instantiate(blockS02D, position + new Vector3(-0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                        }

                    }

                    if (i == 15)
                    {
                        GameObject border, border2, border3;
                        if (j == -1)
                        {
                            border = Instantiate(blockSpike01D, position + new Vector3(0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS01D, position + new Vector3(-0.5f, 1.5f, -0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border = Instantiate(blockS02D, position + new Vector3(0.5f, 1.5f, -0.5f), rotation);
                            border.transform.parent = gameObject.transform;
                        }

                        if (j == 15)
                        {
                            border2 = Instantiate(blockSpike02D, position + new Vector3(0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                            border3 = Instantiate(blockS02D, position + new Vector3(-0.5f, 1.5f, 0.5f), rotation);
                            border3.transform.parent = gameObject.transform;
                        }
                        else
                        {
                            border2 = Instantiate(blockS01D, position + new Vector3(0.5f, 1.5f, 0.5f), rotation);
                            border2.transform.parent = gameObject.transform;
                        }

                    }
                    if ((j == -1 || j == 15) && i != -1 && i != 15)
                    {
                        float z = 0.5f;
                        if (j == -1) z = -0.5f;
                        GameObject border, border2;
                        border = Instantiate(blockS01D, position + new Vector3(z, 1.5f, z), rotation);
                        border.transform.parent = gameObject.transform;
                        border2 = Instantiate(blockS02D, position + new Vector3(-z, 1.5f, z), rotation);
                        border2.transform.parent = gameObject.transform;
                    }
                }
            }
        }
        static bool[] flag;
        void turnTurn()
        {
            Plate.turnTurn();
            for (int p = 0; p <= 1; ++p)
            {
                if (flag[p])
                {
                    bool findflag = false;
                    bool findKing = false;
                    int maxvalue = -1, maxx = 0, maxy = 0;
                    for (int i = 0; i < 15; ++i)
                    {
                        for (int j = 0; j < 15; ++j)
                        {
                            if (Plate.plate[i][j] == null || Plate.plate[i][j].player != p) continue;
                            if (Plate.plate[i][j].dizzy > 0) Plate.plate[i][j].dizzy--;
                            if (Plate.plate[i][j].value() > maxvalue)
                            {
                                if (maxvalue < Plate.plate[i][j].value())
                                {
                                    maxvalue = Plate.plate[i][j].value();
                                    maxx = i; maxy = j;
                                }
                            }
                            if (Plate.plate[i][j] is King) findKing = true;
                            if (Plate.plate[i][j] is Flag)
                            {
                                if ((p == 0 && i > 9) || (p == 1 && i < 5))
                                {
                                    Debug.Log("玩家" + p.ToString() + "通过插旗获得胜利。");
                                    //  string answer=Console.ReadKey().Key.ToString();
                                }
                                findflag = true;
                            }
                        }
                    }
                    if (findflag == false)
                    {
                        flag[p] = false;
                        Plate.plate[maxx][maxy] = null;
                    }
                    if (findKing == false)
                    {
                        Debug.Log("玩家" + (1 - p).ToString() + "获得胜利。");
                        //  string answer=Console.ReadKey().Key.ToString();
                    }
                }
            }

            mode = 0;
            player = 1 - player;
            Plate.colRefresh();
        }
        public static int[] stone;


        static void pushMec(int srcx, int srcy, int dstx, int dsty)
        {
            bool move1 = false, move2 = false, move3 = false, move4 = false;
            Piece selpiece;
            if (srcx > 0 && Plate.plate[srcx - 1][srcy] != null && Plate.plate[srcx - 1][srcy].ismechanics() && Plate.plate[srcx - 1][srcy].player == player)
                if (dstx > 0 && (Plate.plate[dstx - 1][dsty] == null || Plate.plate[srcx - 1][srcy] is Ram))
                {
                    if (Plate.plate[dstx - 1][dsty] != null && Plate.plate[dstx - 1][dsty] is Wall) stone[player]++;
                    move1 = true;
                }
            if (srcx < 14 && Plate.plate[srcx + 1][srcy] != null && Plate.plate[srcx + 1][srcy].ismechanics() && Plate.plate[srcx + 1][srcy].player == player)
                if (dstx < 14 && (Plate.plate[dstx + 1][dsty] == null || Plate.plate[srcx + 1][srcy] is Ram))
                {
                    if (Plate.plate[dstx + 1][dsty] != null && Plate.plate[dstx + 1][dsty] is Wall) stone[player]++;
                    move2 = true;
                }
            if (srcy > 0 && Plate.plate[srcx][srcy - 1] != null && Plate.plate[srcx][srcy - 1].ismechanics() && Plate.plate[srcx][srcy - 1].player == player)
                if (dsty > 0 && (Plate.plate[dstx][dsty - 1] == null || Plate.plate[srcx][srcy - 1] is Ram))
                {
                    if (Plate.plate[dstx][dsty - 1] != null && Plate.plate[dstx][dsty - 1] is Wall) stone[player]++;
                    move3 = true;
                }
            if (srcy < 14 && Plate.plate[srcx][srcy + 1] != null && Plate.plate[srcx][srcy + 1].ismechanics() && Plate.plate[srcx][srcy + 1].player == player)
                if (dsty < 14 && (Plate.plate[dstx][dsty + 1] == null || Plate.plate[srcx][srcy + 1] is Ram))
                {
                    if (Plate.plate[dstx][dsty + 1] != null && Plate.plate[dstx][dsty + 1] is Wall) stone[player]++;
                    move4 = true;
                }
            if (move1)
            {
                selpiece = Plate.plate[srcx - 1][srcy];
                selpiece.wait = 0;
                Plate.plate[dstx - 1][dsty] = selpiece;
                Plate.plate[srcx - 1][srcy] = null;
            }
            if (move2)
            {
                selpiece = Plate.plate[srcx + 1][srcy];
                selpiece.wait = 0;
                Plate.plate[dstx + 1][dsty] = selpiece;
                Plate.plate[srcx + 1][srcy] = null;
            }
            if (move3)
            {
                selpiece = Plate.plate[srcx][srcy - 1];
                selpiece.wait = 0;
                Plate.plate[dstx][dsty - 1] = selpiece;
                Plate.plate[srcx][srcy - 1] = null;
            }
            if (move4)
            {
                selpiece = Plate.plate[srcx][srcy + 1];
                selpiece.wait = 0;
                Plate.plate[dstx][dsty + 1] = selpiece;
                Plate.plate[srcx][srcy + 1] = null;
            }
        }
        // Use this for initialization
        void Start()
        {
            PlayerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); // Find the Camera's GameObject from its tag 
            _GameManager = gameObject.GetComponent<GameManager>();

            // init();
            DrawBoard();
            //Plate.init();
            for(int i=0;i<15;i++)
            for(int j=0;j<15;j++)
            if (Plate.plate[i][j] != null)
            {
                GameObject newPiecePrefab = Pillar01Blue;
                if (Plate.plate[i][j].player == 1) { newPiecePrefab = Pillar01Red; }
                Vector3 position = offset + new Vector3(i * 2, 0f, j * 2);
                if (i < 5 || i > 9) position += new Vector3(0f, 0.5f, 0);

                GameObject newPiece = Instantiate(newPiecePrefab, position, rotation);
                //Debug.Log(MapGenerator.floors[1][1]);
                Plate.floors[i][j].GetComponent<BoardSquare>().piece = newPiece;
                
            }

            flag = new bool[2];
            flag[0] = true; flag[1] = true;
            stone = new int[2];
            stone[0] = 1; stone[1] = 1;


        }

        // Update is called once per frame
        void Update()
        {
            // Look for Mouse Inputs
            GetMouseInputs();

        }

        // Detect Mouse Inputs
        void GetMouseInputs()
        {
            Ray _ray;
            RaycastHit _hitInfo;

            // Select a piece if the gameState is 0 or 1
            if (mode == 0)
            {
                // On Left Click
                if (Input.GetMouseButtonDown(0))
                {
                   
                    _ray = PlayerCam.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click

                    Debug.Log("click");
                    // Raycast and verify that it collided
                    if (Physics.Raycast(_ray, out _hitInfo))
                    {
                        Debug.Log("hit0");
                        // Select the piece if it has the good Tag
                        if (_hitInfo.collider.gameObject.tag == ("Cube"))
                        {
                            GameObject boardSquare = _hitInfo.collider.gameObject;
                            Debug.Log("hit");                                       
                            Program.curx = boardSquare.GetComponent<BoardSquare>().posx;
                            Program.cury = boardSquare.GetComponent<BoardSquare>().posy;
                            if (Plate.selectPiece())
                            {
                                Debug.Log("sel");
                                _GameManager.SelectPiece(boardSquare.GetComponent<BoardSquare>().piece);
                                mode = 1;
                                isPush = false;
                                issteal = false;
                                Plate.colRefresh();
                                Plate.calMove(curx, cury);
                            }
                        }
                    }
                }
            }

            // Move the piece if the gameState is 1
            else if (mode == 1)
            {
                Vector2 selectedCoord;

                // On Left Click
                if (Input.GetMouseButtonDown(0))
                {
                    _ray = PlayerCam.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click

                    // Raycast and verify that it collided
                    if (Physics.Raycast(_ray, out _hitInfo))
                    {

                        // Select the piece if it has the good Tag
                        if (_hitInfo.collider.gameObject.tag == ("Cube"))
                        {
                            GameObject gameObject = _hitInfo.collider.gameObject;
                            selectedCoord = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                            Program.curx = gameObject.GetComponent<BoardSquare>().posx;
                            Program.cury = gameObject.GetComponent<BoardSquare>().posy;

                            Plate.colRefresh();
                            Plate.calMove(Plate.selx, Plate.sely);
                            if (Plate.plate[Plate.selx][Plate.sely] != null && !Plate.plate[Plate.selx][Plate.sely].ismechanics())
                            {
                                if (Plate.selx > 0 && Plate.plate[Plate.selx - 1][Plate.sely] != null && Plate.plate[Plate.selx - 1][Plate.sely].ismechanics() && Plate.plate[Plate.selx - 1][Plate.sely].player == player ||
                                        Plate.sely > 0 && Plate.plate[Plate.selx][Plate.sely - 1] != null && Plate.plate[Plate.selx][Plate.sely - 1].ismechanics() && Plate.plate[Plate.selx][Plate.sely - 1].player == player ||
                                        Plate.selx < 14 && Plate.plate[Plate.selx + 1][Plate.sely] != null && Plate.plate[Plate.selx + 1][Plate.sely].ismechanics() && Plate.plate[Plate.selx + 1][Plate.sely].player == player ||
                                        Plate.sely < 14 && Plate.plate[Plate.selx][Plate.sely + 1] != null && Plate.plate[Plate.selx][Plate.sely + 1].ismechanics() && Plate.plate[Plate.selx][Plate.sely + 1].player == player)
                                    if (isPush) Debug.Log(" O 关闭挟持"); else Debug.Log(" O 开启挟持");
                            }
                            issteal = false;
                            if (Plate.plate[Plate.selx][Plate.sely] != null && !Plate.plate[Plate.selx][Plate.sely].ismechanics())
                            {
                                if (Plate.selx > 0 && Plate.plate[Plate.selx - 1][Plate.sely] != null && Plate.plate[Plate.selx - 1][Plate.sely].ismechanics() && Plate.plate[Plate.selx - 1][Plate.sely].player != player ||
                                        Plate.sely > 0 && Plate.plate[Plate.selx][Plate.sely - 1] != null && Plate.plate[Plate.selx][Plate.sely - 1].ismechanics() && Plate.plate[Plate.selx][Plate.sely - 1].player != player ||
                                        Plate.selx < 14 && Plate.plate[Plate.selx + 1][Plate.sely] != null && Plate.plate[Plate.selx + 1][Plate.sely].ismechanics() && Plate.plate[Plate.selx + 1][Plate.sely].player != player ||
                                        Plate.sely < 14 && Plate.plate[Plate.selx][Plate.sely + 1] != null && Plate.plate[Plate.selx][Plate.sely + 1].ismechanics() && Plate.plate[Plate.selx][Plate.sely + 1].player != player)
                                {
                                    issteal = true;
                                    for (int i = Mathf.Max(0, Plate.selx - 2); i <= Mathf.Min(14, Plate.selx + 2); ++i)
                                        for (int j = Mathf.Max(0, Plate.sely - 2 + Mathf.Abs(Plate.selx - i)); j <= Mathf.Min(14, Plate.sely + 2 - Mathf.Abs(Plate.selx - i)); ++j)
                                            if (Plate.plate[i][j] != null && Plate.plate[i][j].player == 1 - player && !Plate.plate[i][j].ismechanics())
                                                issteal = false;
                                }
                                if (issteal) Debug.Log(" P 偷盗");
                            }


                            if (answer == "O")
                            {
                                isPush = !isPush;
                                if (isPush)
                                {
                                    for (int i = 0; i < 15; ++i)
                                        for (int j = 0; j < 15; ++j)
                                            if ((i != Plate.selx - 2 && i != Plate.selx - 1 && i != Plate.selx + 1 && i != Plate.selx + 2 || j != Plate.sely) &&
                                                    (j != Plate.sely - 2 && j != Plate.sely - 1 && j != Plate.sely + 1 && j != Plate.sely + 2 || i != Plate.selx))
                                            {
                                                Plate.plateCol[i][j] = 0;//!!! color.black
                                            }
                                }
                                else
                                {
                                    Plate.colRefresh();
                                    Plate.calMove(Plate.selx, Plate.sely);
                                }
                            }
                            else if (answer == "P" && issteal)
                            {
                                if (curx > 0 && Plate.plate[curx - 1][cury] != null && Plate.plate[curx - 1][cury].ismechanics()) Plate.plate[curx - 1][cury].player = player;
                                if (cury > 0 && Plate.plate[curx][cury - 1] != null && Plate.plate[curx][cury - 1].ismechanics()) Plate.plate[curx][cury - 1].player = player;
                                if (curx < 14 && Plate.plate[curx + 1][cury] != null && Plate.plate[curx + 1][cury].ismechanics()) Plate.plate[curx + 1][cury].player = player;
                                if (cury < 14 && Plate.plate[curx][cury + 1] != null && Plate.plate[curx][cury + 1].ismechanics()) Plate.plate[curx][cury + 1].player = player;
                                turnTurn();
                                return;
                            }
                            else if (answer == "K")
                            {
                                mode = 0;
                                Plate.colRefresh();
                                return;
                            }
                            else
                            {
                                int response = Plate.listenKey(answer);
                                if (response == 0)
                                { //移动，返回0
                                    if (isPush) pushMec(Plate.selx, Plate.sely, curx, cury);
                                    turnTurn();
                                    return;
                                }
                                else if (response != -1)
                                { //不是无效按键
                                    mode = response;
                                    _GameManager.MovePiece(selectedCoord);
                                    Plate.colRefresh();
                                    Plate.calSkill();
                                    return;
                                }
                            }

                        }
                        else
                        {
                            mode = 0;
                            Plate.colRefresh();

                        }
                    }
                }
            }
            else if (mode == 2)
            {
                if (Plate.releaseSkill())
                {
                    turnTurn();
                    return;
                }
            }
        }
    }
}
