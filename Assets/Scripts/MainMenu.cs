using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void MainMenuStartGame()
	{
		SceneManager.LoadScene ("mainLevel", LoadSceneMode.Single);
	}

	public void MainMenuQuit()
	{
		Application.Quit ();
	}

	public void Restart ()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}


}