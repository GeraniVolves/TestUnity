using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTwoPlayers : MonoBehaviour {

	public List<Transform> targets;
	public Vector3 offset;
	public float smoothTime = 0.5f;
	public bool border = true;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	public float MaxDistance;
	private Vector3 velocity;
	private Camera cam;

	void Start() {
		cam = GetComponent<Camera>();
		MaxDistance = cam.orthographicSize*2.4f;
	}
	
	void Update() {
		var distance = Vector3.Distance(targets[0].transform.position, targets[1].transform.position);
		if (distance > MaxDistance) {
			targets[0].position = targets[1].position + (targets[0].position - targets[1].position).normalized * MaxDistance;
			targets[1].position = targets[0].position + (targets[1].position - targets[0].position).normalized * MaxDistance;
		}
	}

	void LateUpdate () {
		if (targets.Count == 0) {
			return;
		}
		Move();
		if (border == true) {
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
		}
	}

	void Move() {
		Vector3 centerPoint = GetCenterPoint();
		Vector3 newPosition = centerPoint + offset;
		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
	}

	float GetGreatestDistance() {
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0; i < targets.Count; i++) {
			bounds.Encapsulate(targets[i].position);
		}
		return bounds.size.x;
	}

	Vector3 GetCenterPoint() {
		if (targets.Count == 1) {
			return targets[0].position;
		}
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0; i < targets.Count; i++) {
			bounds.Encapsulate(targets[i].position);
		}
		return bounds.center;
	}
}
