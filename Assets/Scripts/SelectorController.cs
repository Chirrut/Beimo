using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectorController : MonoBehaviour 
{

	//Stores the list of characters in array
	private GameObject[] characterList;

	//Stores the current index selected by user
	private int selectionIndex= 0;
	private bool isClick;

	//Gets the audio clip and player for selection screen
	public AudioClip selectMusic;
	public AudioSource musicPlayer;

	// Use this for initialization
	void Start () 
	{

		//Creates and stores the list of characters on selection screen
		characterList = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 
		{
			characterList [i] = transform.GetChild(i).gameObject;
			characterList [i].SetActive (false);
		}

		//Plays the selection music
		GameUtils.PlaySound (musicPlayer, selectMusic);

	}

	// Update is called once per frame
	void Update()
	{

		//Checks if the player presses Enter to confirm selection
		if (Input.GetKeyDown (KeyCode.KeypadEnter) && isClick) 
		{
			ConfirmButton ();
		}

	}

    /// <summary>
    /// Selects the character on click
    /// </summary>
    /// <param name="characterIndex"></param>
    public void SelectCharacter(int index)
    {

		//Checks to see if the index selected doesn't match with index of currently selected
		if (index != selectionIndex || characterList[selectionIndex].active == false) 
		{
			//Disables the current index selected 
			characterList [selectionIndex].SetActive (false);

			//Sets the new index as current and enables it
			selectionIndex = index;
			characterList [selectionIndex].SetActive (true);
		}

    }

	/// <summary>
	/// Triggers an event when the confirm button is clicked
	/// </summary>
	public void ConfirmButton()
	{

		//Stores the index of character the user selected
		PlayerPrefs.SetInt ("FighterSelector", selectionIndex);

		//Switches to the fighting stage scene
		SceneManager.LoadScene ("FightingStage");
	}

	/// <summary>
	/// Sets a value indicating whether this <see cref="SelectorController"/> was clicked.
	/// </summary>
	/// <value><c>true</c> if set click; otherwise, <c>false</c>.</value>
	public bool SetClick
	{
		set 
		{
			this.isClick = true;
		}
	}
		
}
