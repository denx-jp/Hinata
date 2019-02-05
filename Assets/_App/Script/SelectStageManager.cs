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
        SceneManager.LoadScene("Scene/Stage_Scene/tutorial_stage");
    }
    public void SelectNormal()
    {
        SceneManager.LoadScene("Scene/Stage_Scene/normal_stage");
    }
    public void SelectHard()
    {
        SceneManager.LoadScene("Scene/Stage_Scene/hard_stage");
    }
}