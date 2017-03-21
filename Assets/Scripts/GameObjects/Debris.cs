using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	// Randomly spins debris - effect only

	Vector3 direction;

	void Start()
	{
		direction = new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f));
	}

	void Update () {
		transform.RotateAround (transform.position, direction, 90.0f*Time.deltaTime);
	}
}
