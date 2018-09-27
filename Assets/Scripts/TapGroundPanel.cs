using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class TapGroundPanel : MonoBehaviour {

	public Rigidbody2D barierRigidbody;
	public float barrierForce = 100f;
	public SkeletonAnimation [] skeletonAnimation;
	string currentAnimation = "";

	void Start () {
		GameObject barrier = GameObject.Find("barrier");
		barierRigidbody = barrier.GetComponent<Rigidbody2D>();
	}

	void OnTriggerStay2D(Collider2D stepPanel) {
			barierRigidbody.AddForce(Vector3.up * barrierForce);
			SetAnimation("Jump", true);
	}
	
	void OnTriggerExit2D(Collider2D stepPanel) {
		barierRigidbody.AddForce(Vector3.down * barrierForce);
		SetAnimation("Idle", true);
	}

	void SetAnimation(string name, bool loop) {
		if (name == currentAnimation)
			return;
		skeletonAnimation[0].state.SetAnimation(0, name, loop);
		skeletonAnimation[1].state.SetAnimation(0, name, loop);
		currentAnimation = name;
	}
}
