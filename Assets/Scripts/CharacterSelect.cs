using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour 
{

	//Stores the selected fighter
	private Fighter fighter;

	//Stores the current index of both fighters
    private int player1Index;
	private int player2Index;

	//Stores whether game object is player 1
	public bool isPlayer1;

	//Stores the other game components requiring selected fighter
	public BattleController battleController;
	public DualObjectiveCamera camera;
	public HUDController hud;
	public CharacterSelect opponentSelect;

	//Stores all the fighters within the selection
	private GameObject[] fighters;

	void Awake()
	{

		//Creates and stores the selected fighters as game objects
		fighters = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 
		{
			fighters [i] = transform.GetChild (i).gameObject;
			fighters [i].SetActive (false);
		}

		//Gets the index of both fighters
		player1Index = PlayerPrefs.GetInt ("FighterSelector");
		if (!isPlayer1) 
		{
			player2Index = CalcPlayer2 ();
		}

		//Makes the fighters visible and gets fighter script for fighters
		if (isPlayer1) 
		{
			fighters [player1Index].SetActive (true);
			fighter = fighters [player1Index].GetComponent<Fighter> ();
		} 
		else 
		{
			fighters [player2Index].SetActive (true);
			fighter = fighters [player2Index].GetComponent<Fighter> ();
		}
			
		//Sets up the other components of fight stage based on who is the player
		if (isPlayer1) 
		{
			battleController.player1 = fighters [player1Index].GetComponent<Fighter> ();
			camera.leftTarget = fighters [player1Index].transform;
			hud.player1 = fighters [player1Index].GetComponent<Fighter> ();
		} 
		else 
		{
			battleController.player2 = fighters [player2Index].GetComponent<Fighter> ();
			camera.rightTarget = fighters [player2Index].transform;
			hud.player2 = fighters [player2Index].GetComponent<Fighter> ();
		}
					
	}

	void Start()
	{
		
		//Assigns opponent script to fighter
		fighter.opponent = opponentSelect.fighter;

	}

	/// <summary>
	/// Calculates the chracter that will be selected for player 2
	/// </summary>
	/// <returns>The player2.</returns>
	private int CalcPlayer2()
	{

		//Returns a random index for user to fight
		if (Random.value > 0.5) 
		{
			return 1;
		} 
		else 
		{
			return 0;
		}

	}
  
}
