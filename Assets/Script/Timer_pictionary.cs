using UnityEngine;
using System.Collections;
using Timers;
using UnityEngine.UI;

public class Timer_pictionary : MonoBehaviour
{
    public GameObject TB;

    void Timer() { }
    void Start()
    {
        TimersManager.SetTimer(this, 1f, 60, Timer);
        TimersManager.SetPaused(Timer, true);
    }

    public void StartTimer()
    {

        TimersManager.SetTimer(this, 1f, 60, Timer);

    }

    public void ResetTimer()
    {
        TimersManager.SetTimer(this, 1f, 60, Timer);
        TimersManager.SetPaused(Timer, true);
    }

    public void SelectPlayer()
    {
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().SetCurrentState(GameManager.GameState.SelectPlayer);
    }

    void Update()
    {
        if (TimersManager.RemainingTime(Timer) == -1)
        {
            TimersManager.SetTimer(this, 0f, delegate { Destroy(this); });
            TB.GetComponent<Text>().text = "Time Over";
            StartCoroutine("TimeOver");

        }
        else
        {
            TB.GetComponent<Text>().text = "残り時間:" + (int)TimersManager.RemainingTime(Timer) + "秒";
        }

    }

    IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(3);
        TimersManager.SetTimer(this, 1f, 60, Timer);
        TimersManager.SetPaused(Timer, true);

    }
}
