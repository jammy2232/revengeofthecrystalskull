using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSkull : MonoBehaviour {

	public bool collected = false;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			collected = true;
			GetComponent<MeshRenderer> ().enabled = false;
			GetComponent<Collider> ().enabled = false;
		}

	}

}
