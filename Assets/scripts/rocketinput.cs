using UnityEngine;
using System.Collections;

public class rocketinput : MonoBehaviour {

    Rigidbody rocketBody;
    public int defaultForceMultiplier;
    public float rotateSpeed;
    public KeyCode leftControl;
    public KeyCode rightControl;
    public KeyCode thrusterControl;
    public int controlDefault;


	// Use this for initialization
	void Start () {
        rocketBody = GetComponent<Rigidbody>();
        if (controlDefault == 1)
        {
            leftControl = KeyCode.LeftArrow;
            rightControl = KeyCode.RightArrow;
            thrusterControl = KeyCode.UpArrow;
        }
        else if (controlDefault == 2)
        {
            leftControl = KeyCode.A;
            rightControl = KeyCode.D;
            thrusterControl = KeyCode.W;
        }
        else if (controlDefault == 3)
        {
            leftControl = KeyCode.J;
            rightControl = KeyCode.L;
            thrusterControl = KeyCode.I;
        }
        else if (controlDefault == 4)
        {
            leftControl = KeyCode.Keypad4;
            rightControl = KeyCode.Keypad6;
            thrusterControl = KeyCode.Keypad8;
        }
	}
	
	// Update is called once per frame
	void Update ()
    { 
        //left arrow is 276, right arrow 275, up arrow 273
        if (Input.GetKey(leftControl) && rocketBody.rotation.eulerAngles.x >= Vector3.left.x)
        {
            rocketBody.transform.Rotate(Vector3.left * Time.deltaTime * rotateSpeed);
        }

        if (Input.GetKey(rightControl) && rocketBody.rotation.eulerAngles.x <= Vector3.right.x)
        {
            rocketBody.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
        }


        if (Input.GetKey(thrusterControl))
        {
            rocketBody.AddForce(rocketBody.transform.forward * defaultForceMultiplier * Time.deltaTime, ForceMode.Force);
        }
    }
}
