using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public float jumpPower = 700f;
	public float move;
	public string horizontalAxisKey;
	public string jumpKey;
	public SkeletonAnimation skeletonAnimation;
	Rigidbody2D rb2D;
	bool isGrounded = true;
	string currentAnimation = "";
		
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		move = Input.GetAxis (horizontalAxisKey);	
	}
	
	void Update () {
		rb2D.velocity = new Vector2 (move * speed, rb2D.velocity.y);
		if (Input.GetButtonDown (jumpKey) && isGrounded) {
			rb2D.AddForce (new Vector2(0, jumpPower));
			isGrounded = false;
		}
		
		if (move > 0) {
			transform.localRotation = Quaternion.Euler(0, 0, 0);
			SetAnimation("Run", true);
		}
		else if (move < 0) {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
			SetAnimation("Run", true);
		}
		else {
			SetAnimation("Idle", true);
		}
	}

	void SetAnimation(string name, bool loop) {
		if (name == currentAnimation)
			return;
		skeletonAnimation.state.SetAnimation(0, name, loop);
		currentAnimation = name;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "barrier") {
			SceneManager.LoadScene("GameOver");
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}
}
