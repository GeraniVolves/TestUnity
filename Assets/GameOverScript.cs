using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	public void Restart() {
		SceneManager.LoadScene("Game");
	}

	public void ReturnMainMenu() {
		SceneManager.LoadScene("MainMenu");
	}
}
