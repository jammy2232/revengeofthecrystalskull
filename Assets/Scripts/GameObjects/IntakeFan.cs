using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntakeFan : MonoBehaviour {

	[Range(-1.0f,1.0f)]
	public float fanRotation;
	private bool paused;

	// Use this for initialization
	void Start () {

		paused = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (paused == false) 
		{
			transform.Rotate (new Vector3 (0, 0, fanRotation));
		}
		
	}

	public void pause(bool state)
	{
		paused = state;
	}
}
