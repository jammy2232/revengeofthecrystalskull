using UnityEngine;
using System.Collections;

public class rocketinput : MonoBehaviour {

    public Rigidbody rocketBody;
    public float defaultForceMultiplier;
    private Vector3 direction;
    private float thrusterForce;
    public Vector3 startingDirection;
    public string controlLeft;
    public string controlRight;
    public string controlThruster;

	// Use this for initialization
	void Start () {
        direction = startingDirection;
        thrusterForce = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(controlLeft)) //replace with airconsole input
        {
           direction.Set()
        }
	}
}
