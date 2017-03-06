using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntakeFan : MonoBehaviour {

	[Range(-1.0f,1.0f)]
	public float fanRotation;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {


		transform.Rotate (new Vector3 (0, fanRotation, 0));

		
	}
}
