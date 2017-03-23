using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedPort : MonoBehaviour {

	ParticleSystem flames;
	BoxCollider flameBody;
	float elapsedTime;
	public float waitTime;
	bool on;

	// Use this for initialization
	void Start () {

		flames = GetComponentInChildren<ParticleSystem> ();
		flameBody = (GetComponentsInChildren<BoxCollider> ())[1]; // Indexed as 1 to get the first child and not parent
		elapsedTime = 0;
		on = false;
	}

	void Update(){
		if (elapsedTime > waitTime) {
			elapsedTime = 0;
			if (on) {
				on = false;
				turnExhaustOff ();
			} else {
				on = true;
				turnExhaustOn ();
			}
		}
		elapsedTime += Time.deltaTime;
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
