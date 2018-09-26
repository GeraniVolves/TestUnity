using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Shooter : MonoBehaviour {

		public float speed = 10f;
		public float jumpPower = 600f;
		public Transform groundCheck;
		public LayerMask ground;
		public float groundRadius = 0.3f;
		public float move;
		Rigidbody2D rb2D;

		public SkeletonAnimation skeletonAnimation;
		string currentAnimation = "";

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
			skeletonAnimation.state.SetAnimation(0, "JumpUp", true);
			}
		

		

		if (move > 0) {
			transform.localRotation = Quaternion.Euler(0,0,0);
			SetAnimation("Run", true);
		}
		else if (move < 0) {
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
}
