using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;  
	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;
	public GameObject Panel4;
	public GameObject Panel5;
	public GameObject Panel6;

	public GameObject Panel1Obj;
	public GameObject Panel2Obj;
	public GameObject Panel3Obj;
	public GameObject Panel4Obj;
	public GameObject Panel5Obj;
	public GameObject Panel6Obj;

	Vector3 pos;
	Vector3 start;
	Vector3 pos2 = new Vector3(0,-10, -10);
	Vector3 pos3 = new Vector3(0,-20, -10);
	Vector3 pos4 = new Vector3(0,-35, -10);
	Vector3 pos5 = new Vector3(0,-45, -10);
	Vector3 pos6 = new Vector3(0,-60, -10);

	void Start()
	{
		pos = transform.position;
		start = transform.position;
		Panel2.SetActive (false);
		Panel3.SetActive (false);
		Panel4.SetActive (false);
		Panel5.SetActive (false);
		Panel6.SetActive (false);
		Panel2Obj.SetActive (false);
		Panel3Obj.SetActive (false);
		Panel4Obj.SetActive (false);
		Panel5Obj.SetActive (false);
		Panel6Obj.SetActive (false);

	}

	void Update()
	{

		transform.position = Vector3.SmoothDamp (transform.position, pos, ref velocity, 0.3f);

	}

	public void moveToPanel2()
	{
		Panel1.SetActive (false);
		Panel1Obj.SetActive (false);
		Panel2.SetActive (true);
		Panel2Obj.SetActive (true);
		pos = pos2;
		start = transform.position;
	}

	public void moveToPanel3()
	{
		Panel2.SetActive (false);
		Panel2Obj.SetActive (false);
		Panel3.SetActive (true);
		Panel3Obj.SetActive (true);
		pos = pos3;
		start = transform.position;
	}

	public void moveToPanel4()
	{
		Panel3.SetActive (false);
		Panel3Obj.SetActive (false);
		Panel4.SetActive (true);
		Panel4Obj.SetActive (true);
		pos = pos4;
		start = transform.position;
	}

	public void moveToPanel5()
	{
		Panel4.SetActive (false);
		Panel4Obj.SetActive (false);
		Panel5.SetActive (true);
		Panel5Obj.SetActive (true);
		pos = pos5;
		start = transform.position;
	}

	public void moveToPanel6()
	{
		Panel6.SetActive (true);
		Panel6Obj.SetActive (true);
		Panel5.SetActive (false);
		Panel5Obj.SetActive (false);
		pos = pos6;
		start = transform.position;
	}

	public void EndTut()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
		
}
