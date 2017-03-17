using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody playerShip;
	public float thrusterDefaultForce;

	public ParticleSystem thruster1Rocket;
	public ParticleSystem thruster2Rocket;
	public ParticleSystem thruster3Rocket;
	public ParticleSystem thruster4Rocket;

	private Vector3 thruster1Dir;
	private Vector3 thruster2Dir;
	private Vector3 thruster3Dir;
	private Vector3 thruster4Dir;

	private float thruster1Force;
	private float thruster2Force;
	private float thruster3Force;
	private float thruster4Force;


	// Use this for initialization
	void Start () {

		thruster1Dir = new Vector3(1,0,0);
		thruster2Dir = new Vector3(0,0,1);
		thruster3Dir = new Vector3(-1,0,0);
		thruster4Dir = new Vector3(0,0,-1);

		thruster1Force = 0.0f;
		thruster2Force = 0.0f;
		thruster3Force = 0.0f;
		thruster4Force = 0.0f;

		thruster1Rocket.Stop();
		thruster2Rocket.Stop();
		thruster3Rocket.Stop();
		thruster4Rocket.Stop();
	
	}

	// Update is called once per frame
	void Update () {

		// Thrusters Controls
		if (Input.GetKeyDown (KeyCode.D)) {
			thruster1Force = thrusterDefaultForce;
			thruster1Rocket.Play();
		} else if(Input.GetKeyUp(KeyCode.D)) {
			thruster1Force = 0;
			thruster1Rocket.Stop();
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			thruster2Force = thrusterDefaultForce;
			thruster2Rocket.Play();
		} else if(Input.GetKeyUp(KeyCode.S)) {
			thruster2Force = 0;
			thruster2Rocket.Stop();
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			thruster3Force = thrusterDefaultForce;
			thruster3Rocket.Play();
		} else if(Input.GetKeyUp(KeyCode.A)) {
			thruster3Force = 0;
			thruster3Rocket.Stop();
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			thruster4Force = thrusterDefaultForce;
			thruster4Rocket.Play();
		} else if(Input.GetKeyUp(KeyCode.W)) {
			thruster4Force = 0;
			thruster4Rocket.Stop();
		}

	}

	// Update is called once per frame
	void FixedUpdate () 
	{

		playerShip.AddRelativeForce (thruster1Dir * thruster1Force);
		playerShip.AddRelativeForce (thruster2Dir * thruster2Force);
		playerShip.AddRelativeForce (thruster3Dir * thruster3Force);
		playerShip.AddRelativeForce (thruster4Dir * thruster4Force);

	}

}
