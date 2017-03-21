using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer: MonoBehaviour {

	PlayerMovement player;
	Vector3 cameraPos;

	// Use this for initialization
	void Start () {

		// Find the player object and setup the camera's position relative to the player
		player = FindObjectOfType<PlayerMovement> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		// If the player hasn't been found
		if (player == null)
		{
			// Find the player object 
			player = FindObjectOfType<PlayerMovement> ();

			// If it was found in this update complete the camera setup
			if (player != null)
			{
				transform.position = player.transform.position + new Vector3 (0.0f, 0.0f, -10.0f);
				cameraPos = player.transform.position - transform.position;
			}
		} 
		else
		{

			// Track the player position
			transform.position = player.transform.position - cameraPos;
		}
		
	}
}
