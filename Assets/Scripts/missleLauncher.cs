using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missleLauncher : MonoBehaviour {

	public RocketHoming missleType;
	public float rateOffire;
	public Transform target;

	private float timer;
	private Vector3 spawnLocation;
	private Quaternion spawnAngle;
	private Vector3 tradjectory;

	// Use this for initialization
	void Start () {

		timer = 0;
		spawnLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		tradjectory = target.position - transform.position;

		timer += 1 * Time.deltaTime;

		if (timer > rateOffire) {
			timer = 0;
			RocketHoming missle = missleType;
			missle.transform.position = transform.position;
			missle.transform.rotation = transform.rotation;
			Instantiate (missle); 
		}

		
	}

	void FixedUpdate()
	{
		transform.rotation = Quaternion.FromToRotation(Vector3.up, tradjectory);
	}

}
