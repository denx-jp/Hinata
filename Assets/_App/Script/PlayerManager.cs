using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    public string name;
    public GameObject dice;
    // Use this for initialization

    void Start()
    {
        player = GameObject.Find("Player");
        foreach (Transform child in player.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnPlayer()
    {
        foreach (Transform child in player.transform)
        {
            child.gameObject.SetActive(false);
        }
        player.transform.Find(name).gameObject.SetActive(true);


        PlayerCamera.Target = GameObject.Find(name);
        GameObject gamemanager = GameObject.Find("GameManager");
        gamemanager.GetComponent<GameManager>().SetCurrentState(GameManager.GameState.RollDice);

        Vector3 dice_pos = player.transform.Find(name).position;
        Debug.Log(player.transform.Find(name).position);
        dice_pos.y += 12f;
        dice.transform.position = dice_pos;
    }
}
