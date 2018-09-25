using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

		public float speed2 = 10f;
		public float jumpPower2 = 100f;
		public Transform groundCheck;
		public LayerMask ground;
		public float groundRadius = 0.3f;
		public float move2;
		bool facingRight = true;
		Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		move2 = Input.GetAxis ("Horizontal2");
	}
	
	// Update is called once per frame
	void Update () {
		rb2D.velocity = new Vector2 (move2 * speed2, rb2D.velocity.y);
		if (Input.GetButtonDown ("Jump2")) {
			rb2D.AddForce (new Vector2(0, jumpPower2));
		}
		

		if (move2 > 0 && !facingRight)
			Flip ();
		else if (move2 < 0 && facingRight)
			Flip ();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
