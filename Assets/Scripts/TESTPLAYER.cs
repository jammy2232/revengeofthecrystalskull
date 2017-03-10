using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTPLAYER : MonoBehaviour {

	void OnParticleCollision(GameObject other)
	{

		//Vector3 direction = transform.position - other.transform.position;
		//direction = new Vector3 (direction.x, direction.y, 0.0f);

		Debug.Log ("Ouchy ouchy");

		//gameObject.GetComponent<Rigidbody> ().AddForce (direction * 100.0f);

	}
}
