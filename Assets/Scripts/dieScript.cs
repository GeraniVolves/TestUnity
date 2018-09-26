using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dieScript : MonoBehaviour {

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			SceneManager.LoadScene("GameOver");
		}
	}
}
