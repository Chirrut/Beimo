using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour 
{

	//Returns user to main menu
	public void ReturnToMainMenu()
	{
		//Swtiches scene to main menu
		SceneManager.LoadScene ("MainMenu");

	}

	//Enables the main menu button on stage
	public void EnableMainMenuBtn()
	{
		//Gets the gameobject of the main menu button
		transform.Find ("MainMenuButton").gameObject.SetActive (true);

	}
}
