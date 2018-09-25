using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

		public float speed = 10f;
		public float jumpPower = 600f;
		public Transform groundCheck;
		public LayerMask ground;
		public float groundRadius = 0.3f;
		public float move;
		bool facingRight = true;
		Rigidbody2D rb2D;


	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
	}
	// Update is called once per frame
	void Update () {
		rb2D.velocity = new Vector2 (move * speed, rb2D.velocity.y);
		if (Input.GetButtonDown ("Jump")) {
			rb2D.AddForce (new Vector2(0, jumpPower));
		}
		

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
