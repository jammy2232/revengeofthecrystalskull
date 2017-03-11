using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.up, 90.0f*Time.deltaTime);
	}

	void OnTiggerEnter(Collider other)
	{

		if (other.tag == "Player")
		{

			// Do stuff;

		}

	}

}
