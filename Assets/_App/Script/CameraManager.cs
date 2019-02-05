using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	public Camera firstPersonCamera;
	public Camera overheadCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ShowOverheadView() {
		GameObject gamemanager = GameObject.Find ("GameManager");
		gamemanager.GetComponent<GameManager> ().ViewMap.SetActive(false);
		gamemanager.GetComponent<GameManager> ().ViewMap_Arrow.SetActive(true);
		gamemanager.GetComponent<GameManager> ().ViewMap_Return.SetActive(true);
		firstPersonCamera.enabled = false;
		overheadCamera.enabled = true;
	}

	public void ShowCharacterView() {
		GameObject gamemanager = GameObject.Find ("GameManager");
		gamemanager.GetComponent<GameManager> ().ViewMap.SetActive(true);
		gamemanager.GetComponent<GameManager> ().ViewMap_Return.SetActive(false);
		gamemanager.GetComponent<GameManager> ().ViewMap_Arrow.SetActive(false);
		firstPersonCamera.enabled = true;
		overheadCamera.enabled = false;
	}
}
