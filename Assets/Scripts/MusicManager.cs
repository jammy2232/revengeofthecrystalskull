using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (this);

		if (FindObjectsOfType<MusicManager>().Length > 1)
		{
			Destroy (gameObject);
		}
		
	}

	// Can be extended if multiple tracks exist.
	
}
