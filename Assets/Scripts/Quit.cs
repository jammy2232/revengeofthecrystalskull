using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

	public Text needMorePlayers;
	string temp = "";
	private bool quit;

	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyUp(KeyCode.Escape) == true && quit == false)
		{
			temp = needMorePlayers.text; 
			needMorePlayers.text = "PRESS ESC AGAIN TO QUIT OR SPACE TO CONTINUE";
			quit = true;
		}

		if(Input.GetKeyDown(KeyCode.Escape) == true && quit == true)
		{
			SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
		}

		if(Input.GetKeyDown(KeyCode.Space) == true && quit == true)
		{
			quit = false;
			needMorePlayers.text = temp;

		}
		
	}
}
