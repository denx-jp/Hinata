using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePlayer : MonoBehaviour
{
    public GameObject Player;
    public string name;
    Stack myStack = new Stack();
    public static GameObject Player_trans;
    public static bool myturn = false;
    public static int turn = 3;
    int player_num;
    string card_name = "";
    public GameObject Player_fig;
    public GameObject map;

    private int[,] stageArray;
   
    Dictionary<string, int[]> playerpos = new Dictionary<string, int[]>();

    void Awake()
    {
        myStack.Push(" ");
        playerpos.Add("Player1", new[] { 9, 3 });
        playerpos.Add("Player2", new[] { 9, 3 });
        playerpos.Add("Player3", new[] { 9, 3 });
        playerpos.Add("Player4", new[] { 9, 3 });
        playerpos.Add("Player5", new[] { 9, 3 });
        int playerPositionX = playerpos[name][0];
        int playerPositionZ = playerpos[name][1];
        UpdatePlayerPosition(0, 0, name);
        Player_fig.transform.position = new Vector3((playerPositionX) * 10, 0, (playerPositionZ) * 10);
       

    }
    // Use this for initialization
    void Start()
    {
        LoadMapData();
    }

    // Update is called once per frame
    void Update()
    {
        int moveX;
        int moveZ;

        if (myturn == true)
        {
            GameObject gamemanager2 = GameObject.Find("GameManager");
            if (gamemanager2.GetComponent<GameManager>().RemainText_flag == true)
            {
                gamemanager2.GetComponent<GameManager>().ShowRemaining(turn);
            }
            int playerPositionX2 = playerpos[name][0];
            int playerPositionZ2 = playerpos[name][1];
            int playermasu2 = stageArray[playerPositionX2, playerPositionZ2];
            if (playermasu2 == 10)
            {
                turn = 0;
                gamemanager2.GetComponent<GameManager>().ShowRemaining(0);
            }

            if (turn != 0)
            {
                // Keyによってプレイヤーが相対的に何処に移動するかを指定する
                if (Input.GetKeyDown(KeyCode.A) && CheckWall(-1, 0, name) == false)
                {
                    moveX = -1;
                    moveZ = 0;
                    if (myStack.Peek().ToString() == "r")
                    {
                        turn += 1;
                        myStack.Pop();
                    }
                    else
                    {
                        myStack.Push("l");
                        turn -= 1;
                    }
                    UpdatePlayerPosition(moveX, moveZ, name);
                }
                else if (Input.GetKeyDown(KeyCode.D) && CheckWall(1, 0, name) == false)
                {
                    moveX = 1;
                    moveZ = 0;
                    if (myStack.Peek().ToString() == "l")
                    {
                        turn += 1;
                        myStack.Pop();
                    }
                    else
                    {
                        myStack.Push("r");
                        turn -= 1;
                    }
                    UpdatePlayerPosition(moveX, moveZ, name);
                }
                else if (Input.GetKeyDown(KeyCode.W) && CheckWall(0, 1, name) == false)
                {
                    moveX = 0;
                    moveZ = 1;
                    if (myStack.Peek().ToString() == "b")
                    {
                        turn += 1;
                        myStack.Pop();
                    }
                    else
                    {
                        myStack.Push("u");
                        turn -= 1;
                    }
                    UpdatePlayerPosition(moveX, moveZ, name);
                }
                else if (Input.GetKeyDown(KeyCode.S) && CheckWall(0, -1, name) == false)
                {
                    moveX = 0;
                    moveZ = -1;
                    if (myStack.Peek().ToString() == "u")
                    {
                        turn += 1;
                        myStack.Pop();
                    }
                    else
                    {
                        myStack.Push("b");
                        turn -= 1;
                    }
                    UpdatePlayerPosition(moveX, moveZ, name);
                }
            }
            else
            {
                myturn = false;
                GameObject gamemanager = GameObject.Find("GameManager");
                gamemanager.GetComponent<GameManager>().SetCurrentState(GameManager.GameState.Quiz);
                int playerPositionX = playerpos[name][0];
                int playerPositionZ = playerpos[name][1];
                int playermasu = stageArray[playerPositionX, playerPositionZ];
                gamemanager.GetComponent<GameManager>().SwitchMaterial(playermasu);
                myStack.Clear();
                myStack.Push(" ");
                Player_fig.transform.position = new Vector3((playerPositionX) * 10, 0, (playerPositionZ) * 10);
            }
        }
    }

    bool CheckWall(int moveX, int moveZ, string player_name)
    {
        bool wall = false;
        int playerPositionX = playerpos[player_name][0];
        int playerPositionZ = playerpos[player_name][1];

        // 移動先が壁だった場合はreturnそれ以外の場合はプレイヤーをitweenによって移動させ,配列を更新する.
        if (stageArray[playerPositionX + moveX, playerPositionZ + moveZ] == 0)
        {
            wall = true;
        }
        else
        {
            wall = false;
        }
        return wall;
    }

    void UpdatePlayerPosition(int moveX, int moveZ, string player_name)
    {
        int playerPositionX = playerpos[player_name][0];
        int playerPositionZ = playerpos[player_name][1];
        Player.transform.position = new Vector3((playerPositionX + moveX) * 10, 0, (playerPositionZ + moveZ) * 10);
        playerpos[player_name][0] = playerPositionX + moveX;
        playerpos[player_name][1] = playerPositionZ + moveZ;
    }

    void LoadMapData()
    {
        stageArray = map.GetComponent<MapManager>().getMapArray();
    }
}