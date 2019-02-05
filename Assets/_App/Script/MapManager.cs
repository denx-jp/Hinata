using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class MapManager : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject floorBlock_O;
    public GameObject floorBlock_P;
    public GameObject floorBlock_A;
    public GameObject floorBlock_D;
    public GameObject floorBlock_AP;
    public GameObject floorBlock_Arrow_Up;
    public GameObject floorBlock_Goal;
    public GameObject wallBlock;

    public string mapCSVfileName;

    // 敵データ格納用の配列データ(とりあえず初期値はnull値)
    private int[,] stageArray;


    // CSVから切り分けられた文字列型２次元配列データ 
    private string[,] sdataArrays;

    //読み込めたか確認の表示用の変数
    private int height = 0;    //行数
    private int width = 0;    //列数



    // CSVデータを文字列型２次元配列に変換する
    //                      ファイルパス,変換される配列の値(参照渡し)
    private void readCSVData(string path, ref string[,] sdata)
    {
        // ストリームリーダーsrに読み込む
        StreamReader sr = new StreamReader(path);
        // ストリームリーダーをstringに変換
        string strStream = sr.ReadToEnd();
        // StringSplitOptionを設定(要はカンマとカンマに何もなかったら格納しないことにする)
        System.StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries;

        // 行に分ける
        string[] lines = strStream.Split(new char[] { '\r', '\n' }, option);

        // カンマ分けの準備(区分けする文字を設定する)
        char[] spliter = new char[1] { ',' };

        // 行数設定
        int h = lines.Length;
        // 列数設定
        int w = lines[0].Split(spliter, option).Length;

        // 返り値の2次元配列の要素数を設定
        sdata = new string[h, w];

        // 行データを切り分けて,2次元配列へ変換する
        for (int i = 0; i < h; i++)
        {
            string[] splitedData = lines[i].Split(spliter, option);

            for (int j = 0; j < w; j++)
            {
                sdata[i, j] = splitedData[j];
            }
        }

        // 確認表示用の変数(行数、列数)を格納する
        this.height = h;    //行数   
        this.width = w;    //列数
    }

    // ２次元配列の型を文字列型から整数値型へ変換する
    private void convert2DArrayType(ref string[,] sarrays, ref int[,] iarrays, int h, int w)
    {
        iarrays = new int[h, w];
        for (int i = 0; i < h; i++)
        {
            for (int j = 0; j < w; j++)
            {
                iarrays[i, j] = int.Parse(sarrays[i, j]);
            }
        }
    }



    //確認表示用の関数
    //引数：2次元配列データ,行数,列数
    private void WriteMapDatas(int[,] arrays, int hgt, int wid)
    {
        for (int i = 0; i < hgt; i++)
        {

            for (int j = 0; j < wid; j++)
            {
                //行番号-列番号:データ値 と表示される
                Debug.Log(i + "-" + j + ":" + arrays[i, j]);
            }
        }
    }

    public int[,] getMapArray()
    {
        return stageArray;
    }

    void Awake()
    {
        var filePath = Application.streamingAssetsPath + "/Map/" + mapCSVfileName;
        readCSVData(filePath, ref this.sdataArrays);
        convert2DArrayType(ref this.sdataArrays, ref this.stageArray, this.height, this.width);
    }

    void Start()
    {
        for (int i = 0; i < stageArray.GetLength(0); i++)
        {
            for (int j = 0; j < stageArray.GetLength(1); j++)
            {
                GameObject childObject;
                switch (stageArray[i, j])
                {
                    case 1:
                        childObject = Instantiate(floorBlock_O, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 180, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 2:
                        childObject = Instantiate(floorBlock_P, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 180, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 3:
                        childObject = Instantiate(floorBlock_A, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 180, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 4:
                        childObject = Instantiate(floorBlock_D, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 180, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 5:
                        childObject = Instantiate(floorBlock_AP, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 180, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 6:
                        childObject = Instantiate(floorBlock_Arrow_Up, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 90, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 7:
                        childObject = Instantiate(floorBlock_Arrow_Up, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, -90, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 8:
                        childObject = Instantiate(floorBlock_Arrow_Up, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 180, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 9:
                        childObject = Instantiate(floorBlock_Arrow_Up, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 0, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;
                    case 10:
                        childObject = Instantiate(floorBlock_Goal, new Vector3(i * 10, -1, j * 10), Quaternion.Euler(0, 180, 0)) as GameObject;
                        childObject.transform.SetParent(parentObject.transform);
                        break;

                }
            }
        }
    }
}

