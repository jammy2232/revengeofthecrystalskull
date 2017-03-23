using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedPort : MonoBehaviour {

	ParticleSystem flames;
	BoxCollider flameBody;
	float elapsedTime;
	public float waitTime;
	bool on;
	bool endgamestate;

	// Use this for initialization
	void Start () {

		flames = GetComponentInChildren<ParticleSystem> ();
		flameBody = (GetComponentsInChildren<BoxCollider> ())[1]; // Indexed as 1 to get the first child and not parent
		elapsedTime = 0;
		on = false;
		endgamestate = false;
	}

	void Update(){
		if (endgamestate == false) {
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
		} else {
			turnExhaustOff ();
		}
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

	public void EndGameState()
	{
		endgamestate = true;
	}

}
