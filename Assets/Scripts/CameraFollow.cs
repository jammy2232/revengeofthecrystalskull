using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	TESTPLAYER temp;
	Vector3 cameraPos;

	// Use this for initialization
	void Start () {

		temp = FindObjectOfType<TESTPLAYER> ();
		cameraPos = temp.transform.position - transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = temp.transform.position - cameraPos;
		
	}
}
