using UnityEngine;
using System.Collections;

public class rocketinput : MonoBehaviour {

    public Rigidbody rocketBody;
    public int defaultForceMultiplier;
    public float rotateSpeed;
    public KeyCode leftControl;
    public KeyCode rightControl;
    public KeyCode thrusterControl;
    public ParticleSystem particles;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    { 
        //left arrow is 276, right arrow 275, up arrow 273
        if (Input.GetKey(leftControl)) //replace with airconsole input
        {
            rocketBody.transform.Rotate(Vector3.left * Time.deltaTime * rotateSpeed);
        }

        if (Input.GetKey(rightControl))
        {
            rocketBody.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
        }


        if (Input.GetKey(thrusterControl))
        {
            rocketBody.AddForce(rocketBody.transform.forward * defaultForceMultiplier * Time.deltaTime, ForceMode.Force);
            particles.Play();
        }

        if (!(Input.GetKey(thrusterControl)))
        {
            particles.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
