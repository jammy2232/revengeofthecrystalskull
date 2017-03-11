using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{

		Vector3 direction = transform.position - other.transform.position;
		direction = new Vector3 (0.0f, direction.y, 0.0f);

		direction.Normalize ();

		other.gameObject.GetComponent<Rigidbody> ().velocity = -direction * 5.0f;
	}
}
