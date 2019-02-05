using UnityEngine;
using System.Collections;

public class AnimatorManager : MonoBehaviour {

    public Animator _animator;
    public GameObject gameManager;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        if (gameManager.GetComponent<GameManager>().currentGameState == GameManager.GameState.MovePlayer)
        {
            _animator.SetBool("run_flag",true);
        }

        if (gameManager.GetComponent<GameManager>().currentGameState == GameManager.GameState.Quiz)
        {
            _animator.SetBool("run_flag", false);
        }

    }
}
