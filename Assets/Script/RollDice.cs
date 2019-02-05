using UnityEngine;
using System.Collections;

public class RollDice : MonoBehaviour
{
    private int value;
    private bool diceRoll;
    public Animator _animator;

    // Use this for initialization
    void Start()
    {
        diceRoll = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (diceRoll == true)
        {
            UpdateRoll();
        }
    }

    public void UpdateRoll()
    {
        value = Random.Range(1, 6);
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().ShowDice(value);
    }

    public void StopDice()
    {
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().SetCurrentState(GameManager.GameState.MovePlayer);
        MovePlayer.turn = value;
        MovePlayer.myturn = true;
        _animator.SetTrigger("rollDice");
        gamemanager.GetComponent<GameManager>().ShowRemaining(value);
        diceRoll = false;
    }

    void OnEnable()
    {
        diceRoll = true;
    }

    string randomColor
    {
        get
        {
            string _color = "blue";
            int c = System.Convert.ToInt32(Random.value * 6);
            switch (c)
            {
                case 0: _color = "red"; break;
                case 1: _color = "green"; break;
                case 2: _color = "blue"; break;
                case 3: _color = "yellow"; break;
                case 4: _color = "white"; break;
                case 5: _color = "black"; break;
            }
            return _color;
        }
    }
}
