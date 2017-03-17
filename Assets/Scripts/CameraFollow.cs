using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	PlayerMovement player;
	Vector3 cameraPos;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerMovement> ();
		transform.position = player.transform.position + new Vector3 (0.0f, 0.0f, -10.0f);
		cameraPos = player.transform.position - transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

			transform.position = player.transform.position - cameraPos;
		
	}
}
