using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

	/// <summary>
	/// Sends the game to selection screen
	/// </summary>
	public void PlayGame()
	{
        SceneManager.LoadScene("CharacterSelect");
	}

	/// <summary>
	/// Ends the game
	/// </summary>
	public void QuitGame()
	{
		Application.Quit ();
	}

}
