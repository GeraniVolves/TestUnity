using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGroundPanel : MonoBehaviour {

	public Rigidbody2D barierRigidbody;

	// Use this for initialization
	void Start () {
		GameObject barrier = GameObject.Find("barrier");
		barierRigidbody = barrier.GetComponent<Rigidbody2D>();
	}

	void OnTriggerStay2D(Collider2D stepPanel) {
		if (stepPanel.gameObject.tag == "Player") {
			//rb2D.velocity = new Vector2 (0, rb2D.velocity.y);
			barierRigidbody.AddForce(Vector3.up * 17f);
			Debug.Log("Alive!");
		}
	}
}
