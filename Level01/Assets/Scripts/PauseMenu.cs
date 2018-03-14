using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gamePaused = false;
	public GameObject pauseMenuUI;

	void Start() {
		pauseMenuUI.SetActive (false);
	}
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown (KeyCode.Escape)) {
			if (gamePaused)
				Resume ();
			else
				Pause ();
		}
	}

	public void Resume() {
		pauseMenuUI.SetActive (false); //disable the pause menu
		Time.timeScale = 1f; //normal rate of game
		gamePaused = false;
	}

	public void Pause() {
		pauseMenuUI.SetActive (true); //enable the pause menu
		Time.timeScale = 0f; //freezes game
		gamePaused = true;
	}

	public void Menu() {
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame() {
		Application.Quit();
	}
}
