using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGround : MonoBehaviour {

	public GameObject player;
	public GameObject barrier;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		barrier = GameObject.Find("barrier");
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D stepPanel){
		if(stepPanel.gameObject.tag == "Player") {
			barrier.transform.position = new Vector2(18.92f, 10f);
		}	
	}
	void OnTriggerExit2D(Collider2D stepPanel) {
		barrier.transform.position = new Vector2(18.92f, 6f);
	}
}
