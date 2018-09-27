using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class StepPanelAnimation : MonoBehaviour {

	public SkeletonAnimation skeletonAnimation;
	string currentAnimation = "";

	void SetAnimation(string name, bool loop) {
		if (name == currentAnimation)
			return;
		skeletonAnimation.state.SetAnimation(0, name, loop);
		currentAnimation = name;
	}

	void OnTriggerStay2D(Collider2D stepPanel) {
		SetAnimation("Jump", true);
	}
}
