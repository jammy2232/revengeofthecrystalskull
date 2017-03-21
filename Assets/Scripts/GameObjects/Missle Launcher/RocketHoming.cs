using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHoming : MonoBehaviour {

	// Components required to add the basic Homing rocket functionality
	public ParticleSystem thruster;
	public ParticleSystem Explotion;
	public PlayerMovement target;

	// Private components for calculations
	private Transform rocketT;
	private Rigidbody rocketRB;
	private Collider rocketCollider;

	// Variables that effect missle performance
	public float rocketSpeed;
	public float rocketTurningSpeed;
	public float lockOnTime; // time the missle will follow before defaulting straight
	public float startLag; // future feature

	// Variavbles used for internal calculations
	private Vector3 targetTradjectory;
	private float timer;
	private bool startInhibit;

	// Use this for initialization
	void Start () {
		
		rocketRB = GetComponent<Rigidbody> ();
		rocketT = GetComponent<Transform> ();

		target = FindObjectOfType<PlayerMovement>();

		thruster.Stop ();

		timer = 0;
		startInhibit = true;
		thruster.Play ();

	}
	
	// Update is called once per frame
	void Update () {

		if (startInhibit == false) 
		{
			// Tracking the player
			targetTradjectory = target.transform.position - rocketT.position;

			// Time it's able to track the player
			if (timer < lockOnTime) 
			{
				timer += 1 * Time.deltaTime;
			}
		}
		else 
		{

			timer += 1 * Time.deltaTime;

			if (timer > startLag) 
			{
				startInhibit = false;
				timer = 0;
				thruster.Play ();
			}
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			Vector3 pushBackForce = transform.position - other.transform.position;
			other.GetComponent<Rigidbody> ().AddForce (-pushBackForce.normalized*200.0f);
		}

		if (other.tag != "Button")
		{
			Instantiate (Explotion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

	}

	void FixedUpdate()
	{
		if (startInhibit == false) 
		{
			// Move the rocket forwared
			rocketRB.velocity = (rocketT.up * rocketSpeed);

			// Rotate the rocket toward the player
			Vector3 crossCheck = Vector3.Cross (rocketT.up, targetTradjectory);

			if (crossCheck.z > 0 && timer < lockOnTime) 
			{
				rocketT.Rotate (0f, 0f, rocketTurningSpeed * Time.deltaTime);
			} 
			else if (crossCheck.z < 0 && timer < lockOnTime) 
			{
				rocketT.Rotate (0f, 0f, -rocketTurningSpeed * Time.deltaTime);
			}
		}
	}
}
