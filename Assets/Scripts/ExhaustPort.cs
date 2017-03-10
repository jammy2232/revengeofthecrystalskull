using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustPort : MonoBehaviour {

	ParticleSystem flames;
	BoxCollider flameBody;

	// Use this for initialization
	void Start () {

		flames = GetComponentInChildren<ParticleSystem> ();
		flameBody = (GetComponentsInChildren<BoxCollider> ())[1]; // Indexed as 1 to get the first child and not parent
		
	}


	public void turnExhaustOn () 
	{
		var test = flames.emission;
		flameBody.enabled = true;
		test.enabled = true;	
	}


	public void turnExhaustOff()
	{
		var test = flames.emission;
		test.enabled = false;	
		flameBody.enabled = false;
	}

}
