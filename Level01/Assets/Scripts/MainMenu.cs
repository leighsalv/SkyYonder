using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //loads scenes

public class MainMenu : MonoBehaviour {

	// Play button clicked
	public void Play () {
		//loads next scene in the queue
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
