using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndArea : MonoBehaviour {

	public bool playerPresent = false;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			playerPresent = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			playerPresent = false;
		}
	}

}
