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
    Vector3 startingPos;
    float leftLimit;
    float rightLimit;
    public Rigidbody shipBody;

	private bool[] userControls;


	// Use this for initialization
	void Start () {

		userControls = FindObjectOfType<GameManager> ().GetComponent<AirConsoleLogic> ().GetThrusters();

		for (int i = 0; i < userControls.Length; i++) {
			Debug.Log (i + " = " + userControls [i]);
		}

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

        startingPos = rocketBody.transform.localRotation.eulerAngles;
        leftLimit = startingPos.y - 90;
        rightLimit = startingPos.y + 90;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (userControls[1] != null) {

			//left arrow is 276, right arrow 275, up arrow 273
			if (Input.GetKey (leftControl) && rocketBody.transform.localRotation.eulerAngles.y <= rightLimit) {
				rocketBody.transform.Rotate (Vector3.left * Time.deltaTime * rotateSpeed);
			}

			if (Input.GetKey (rightControl) && rocketBody.transform.localRotation.eulerAngles.y >= leftLimit) {
				rocketBody.transform.Rotate (Vector3.right * Time.deltaTime * rotateSpeed);
			}

			/*
			if (Input.GetKey (thrusterControl) || userControls [controlDefault - 1]) {
				rocketBody.AddForce (rocketBody.transform.forward * defaultForceMultiplier * Time.deltaTime, ForceMode.Force);
			}
			*/

			// Debug.Log (controlDefault + " user = " + userControls [controlDefault - 1]);
		}

		// add message to screen waiting for players

    }
}
// 