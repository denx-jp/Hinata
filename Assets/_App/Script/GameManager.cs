using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject SelectPlayerButton;
    public GameObject PlayerSelection;
    public GameObject ViewMap;
    public GameObject ViewMap_Return;
    public GameObject ViewMap_Arrow;
    public GameObject diceText;
    public GameObject RemainingText;
    public bool RemainText_flag = false;

    public GameObject DiceButtons;
    public GameObject Dice;

    public GameObject Timer;

    public GameObject TileImage;
    public Sprite[] _material;
    public GameObject Player;

    public GameState currentGameState;

    public enum GameState
    {
        SelectPlayer,
        RollDice,
        MovePlayer,
        Quiz,
        End
    }

    // Use this for initialization
    void Start()
    {
        SetCurrentState(GameState.SelectPlayer);
    }

    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
        OnGameStateChanged(currentGameState);
    }

    public GameState getCurrentState()
    {
        return currentGameState;
    }

    void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.SelectPlayer:
                SelectPlayerAction();
                break;
            case GameState.RollDice:
                RollDiceAction();
                break;
            case GameState.MovePlayer:
                MovePlayerAction();
                break;
            case GameState.Quiz:
                QuizAction();
                break;
            default:
                break;
        }


    }

    void SelectPlayerAction()
    {
        CloseRemaining();
        CloseTimer();
        CloseDiceButton();
        ShowSelectPlayerButton();
    }

    void RollDiceAction()
    {
        Dice.SetActive(true);
        CloseSelectPlayer();
        CloseTimer();
        ShowDiceButton();
    }

    void MovePlayerAction()
    {

        CloseDiceButton();
        CloseSelectPlayer();
        StartCoroutine("CloseDice");
    }

    void QuizAction()
    {
        CloseDiceButton();
        CloseSelectPlayer();
        ShowTimer();
    }


    void ShowSelectPlayerButton()
    {
        GetComponent<CameraManager>().ShowCharacterView();
        TileImage.SetActive(false);
        ViewMap_Return.SetActive(false);
        ViewMap.SetActive(false);
        ViewMap_Arrow.SetActive(false);
        PlayerSelection.SetActive(true);
        SelectPlayerButton.SetActive(true);
    }
    void CloseSelectPlayer()
    {
        SelectPlayerButton.SetActive(false);
    }

    void ShowDiceButton()
    {
        DiceButtons.SetActive(true);
        ViewMap.SetActive(false);
        ViewMap_Return.SetActive(false);
        PlayerSelection.SetActive(false);
        GetComponent<CameraManager>().ShowCharacterView();
        ViewMap_Arrow.SetActive(false);
    }
    void CloseDiceButton()
    {
        DiceButtons.SetActive(false);
        GetComponent<CameraManager>().ShowCharacterView();
        ViewMap.SetActive(true);
    }

    void ShowTimer()
    {
        Timer.SetActive(true);
    }

    void CloseTimer()
    {
        Timer.SetActive(false);
    }

    public void ShowDice(int dice_num)
    {
        diceText.SetActive(true);
        diceText.GetComponent<Text>().text = dice_num.ToString();
    }

    public void ShowRemaining(int remain_num)
    {
        if (remain_num == 0)
        {
            RemainText_flag = false;
            RemainingText.SetActive(false);
        }
        else
        {
            RemainingText.SetActive(true);
            RemainingText.GetComponent<Text>().text = remain_num.ToString();
            RemainText_flag = true;
        }
    }

    public void CloseRemaining()
    {
        RemainingText.SetActive(false);
    }

    public void SwitchMaterial(int tile)
    {
        TileImage.SetActive(true);
        if (tile == 1)
        {
            TileImage.GetComponent<Image>().sprite = _material[0];
            TileImage.GetComponent<Image>().color = new Color(41 / 255f, 74 / 255f, 255 / 255f);
        }
        if (tile == 2)
        {
            TileImage.GetComponent<Image>().sprite = _material[1];
            TileImage.GetComponent<Image>().color = new Color(252 / 255f, 255 / 255f, 19 / 255f);
        }
        if (tile == 3)
        {
            TileImage.GetComponent<Image>().sprite = _material[2];
            TileImage.GetComponent<Image>().color = new Color(255 / 255f, 168 / 255f, 11 / 255f);
        }
        if (tile == 4)
        {
            TileImage.GetComponent<Image>().sprite = _material[3];
            TileImage.GetComponent<Image>().color = new Color(77 / 255f, 193 / 255f, 48 / 255f);
        }
        if (tile == 5)
        {
            TileImage.GetComponent<Image>().sprite = _material[4];
            TileImage.GetComponent<Image>().color = new Color(255 / 255f, 0 / 255f, 0 / 255f);
        }
    }

    IEnumerator CloseDice()
    {
        yield return new WaitForSeconds(1);
        Dice.SetActive(false);

    }
}
