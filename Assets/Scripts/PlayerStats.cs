using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour 
{

	//Stores the text that displays the total score
	public TextMeshProUGUI playerScoreText;

	//Stores both the total score and score player recently made
	private int totalScore;
	private int currentScore;

	// Use this for initialization
	void Awake () 
	{
		
		//Sets the total points racked up by player
		totalScore = PlayerPrefs.GetInt ("TotalScore");

	}

	/// <summary>
	/// Updates the amount of points the user has
	/// </summary>
	public void UpdateScore()
	{

		//Gets the current score recently made by player
		currentScore = PlayerPrefs.GetInt ("CurrentScore");

		//Calculates and stores the new score the player produced
		totalScore += currentScore;
		playerScoreText.text = totalScore.ToString ();
		PlayerPrefs.SetInt ("TotalScore", totalScore);

		//Resets the current score recently made by player
		PlayerPrefs.DeleteKey ("CurrentScore");

	}

}
