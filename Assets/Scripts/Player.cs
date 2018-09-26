using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

		public float speed2 = 10f;
		public float jumpPower2 = 500f;
		public Transform groundCheck;
		public LayerMask ground;
		public float groundRadius = 0.3f;
		public float move2;
		public string horizontalAxisKey;
		public string jumpKey;
		Rigidbody2D rb2D;

		public SkeletonAnimation skeletonAnimation;
		string currentAnimation = "";

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		move2 = Input.GetAxis (horizontalAxisKey);
		rb2D.velocity = new Vector2 (move2 * speed2, rb2D.velocity.y);
		if (Input.GetButtonDown (jumpKey)) {
			rb2D.AddForce (new Vector2(0, jumpPower2));
		}
	}
	
	// Update is called once per frame
	void Update () {
		

		if (move2 > 0) {
			transform.localRotation = Quaternion.Euler(0,0,0);
			SetAnimation("Run", true);
		}
		else if (move2 < 0) {
			transform.localRotation = Quaternion.Euler(0,180,0);
			SetAnimation("Run", true);
		}
		else {
			SetAnimation("Idle", true);
		}
	}

	void SetAnimation(string name, bool loop) {
		if(name == currentAnimation) 
			return;
		
		skeletonAnimation.state.SetAnimation(0, name, loop);
		currentAnimation = name;

	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "barrier") {
			SceneManager.LoadScene("GameOver");
		}
	}
}
