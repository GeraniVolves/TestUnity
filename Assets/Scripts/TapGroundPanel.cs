using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGroundPanel : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject barrier;
	public GameObject stepPanel;
	public bool isPlayerOnPanel;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("shooter");
		player2 = GameObject.Find("tank");
		barrier = GameObject.Find("barrier");
		stepPanel = GameObject.FindWithTag("Switch");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isPlayerOnPanel == true)
			barrier.transform.Translate(new Vector2(0, Time.deltaTime));
		else {
			barrier.transform.Translate(new Vector2(0, -Time.deltaTime));
		}
		if (barrier.transform.position.y < 6) {
			barrier.transform.position = new Vector2(18.92f, 6f);	
		}
		if (barrier.transform.position.y > 10) {
			barrier.transform.position = new Vector2(18.92f, 10f);
		}
		
	}

	void OnTriggerEnter2D(Collider2D stepPanel){
		if(stepPanel.gameObject.tag == "Player") {
			isPlayerOnPanel = true;
		}	
	}
	void OnTriggerExit2D(Collider2D stepPanel) {
		isPlayerOnPanel = false;
	}
}
