using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGroundPanel : MonoBehaviour {

	public Rigidbody2D barierRigidbody;
	public float barrierForce = 100f;

	void Start () {
		GameObject barrier = GameObject.Find("barrier");
		barierRigidbody = barrier.GetComponent<Rigidbody2D>();
	}

	void OnTriggerStay2D(Collider2D stepPanel) {
		barierRigidbody.AddForce(Vector3.up * barrierForce);
	}
	
	void OnTriggerExit2D(Collider2D stepPanel) {
		barierRigidbody.AddForce(Vector3.down * barrierForce);
	}
}
