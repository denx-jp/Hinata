using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectStageManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelectTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void SelectNormal()
    {
        SceneManager.LoadScene("Normal");
    }
    public void SelectHard()
    {
        SceneManager.LoadScene("Hard");
    }
}