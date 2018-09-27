using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTwoPlayer : MonoBehaviour {

	public Transform [] players;
	Camera cam = GetComponent<Camera>();
	
	void Update () {
		SetCameraPos();
	}

	void SetCameraPos() {
		Vector2 center = Vector2.zero;
		int numPlayers = 0;
		for (int i=0; i < players.Length; ++i) {
			if(players[i]== null) {
				continue;
			}
			center += players[i].position;
			numPlayers++;
		}
		center /= numPlayers;
	}
	cam.transform.position = new Vector2(center.x, transform.position.y);
}
