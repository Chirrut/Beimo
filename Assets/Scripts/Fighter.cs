using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
	//Sets up and stores the fighter's information
	public static float MAX_HEALTH = 100f;
	public float currentHealth = MAX_HEALTH;
	public string fighterName;
    public FighterState currentState =FighterState.IDLE;
	public FighterType fighterType;

	//Stores the information regarding the opponent
	public Fighter opponent;

	//Gets the animator and the rigidbody from game object
	protected Animator animator;
	private Rigidbody rb;
    private AudioSource audioPlayer;

	//Signals whether the fighters can start moving
	public bool enable;

	//AI Only(Randomizes attacks and movements)
    private float random;
    private float randomSetTime;

	// Use this for initialization
	void Start ()
	{
		
		//Gets the components of fighter
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
        audioPlayer = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		//Sets the current health value of player
		animator.SetFloat ("currentHealth", HealthPercent);

		//Sets the opponent's health value
		if (opponent != null) 
		{
			animator.SetFloat ("opponentHealth", opponent.HealthPercent);
		} 
		else
		{
			animator.SetFloat ("opponentHealth", 1f);
		}

		//Checks whether fighters can acutally move
		if (enable) 
		{
			//Checks whether fighter is human or AI
            if (fighterType == FighterType.Human)
            {
				//Enables user input
                UserInput();
            }
            else
            {
				//Enables AI input
                AIInput();
            }
		}

		//Rotates the fighter when they go across their opponent
		if (transform.position.x > CentreOfGame ()) 
		{
			transform.rotation = Quaternion.Euler (transform.rotation.x, -90, transform.rotation.y);
		}
		else 
		{
			transform.rotation = Quaternion.Euler (transform.rotation.x, 90, transform.rotation.y);
		}
			
		//Make fighter dead when health hits zero and makes opponent win
		if (currentHealth <= 0 && currentState != FighterState.DEAD) 
		{
			animator.SetBool ("isDead", true);
			opponent.animator.SetTrigger ("isWon");
		}

	}

	/// <summary>
	/// Checks to see if fighter is attacking
	/// </summary>
	/// <returns><c>true</c> if this instance is attacking; otherwise, <c>false</c>.</returns>
	public bool IsAttacking
	{
        get
        {
            return currentState == FighterState.LEFT_HOOK ||
               currentState == FighterState.HIGH_KICK ||
               currentState == FighterState.LEFT_SIDEKICK ||
               currentState == FighterState.STRAIGHT_RIGHT ||
				currentState == FighterState.SPECIAL||
               currentState == FighterState.STRIAIGHT_LEFT;
        }      
	}

	/// <summary>
	/// Hurts the fighter using the specified damage.
	/// </summary>
	/// <param name="damage">Damage.</param>
	public virtual void Hurt(float damage)
	{
		//Checks if the damage done should not be voided
		if (!IsVoidDamage) 
		{
			//Reduces damage done to 20% if fighter was defending 
			if (IsDefending) 
			{
				damage *= 0.2f;
			}

			//Depletes the current health by the damage done
			if (currentHealth >= damage) 
			{
				currentHealth -= damage;
			} 
			else 
			{
				currentHealth = 0;
			}

			//Checks to see if fighter is still alive
			if (currentHealth > 0) 
			{
				//Sets trigger for hit animation
				animator.SetTrigger("isHit");
			}
		}
	}

	/// <summary>
	/// Voids damges when fighter is in specified state
	/// </summary>
	/// <returns><c>true</c> if this instance is void damage; otherwise, <c>false</c>.</returns>
	public bool IsVoidDamage
	{
        get
        {
			return currentState == FighterState.TAKE_HIT ||
				   currentState==FighterState.DEFEND_HIT||
				   currentState == FighterState.DEAD;
        }
	
	}

	/// <summary>
	/// Gets a value indicating whether this instance is defending.
	/// </summary>
	/// <value><c>true</c> if this instance is defending; otherwise, <c>false</c>.</value>
    public bool IsDefending
    {
        get
        {
			return currentState == FighterState.DEFEND ||
				   currentState == FighterState.DEFEND_HIT;
        }      
    }

	/// <summary>
	/// Plays the sound effect of fighter
	/// </summary>
	/// <param name="sound">Sound.</param>
	public void PlaySoundEffect(AudioClip sound)
	{
		GameUtils.PlaySound (audioPlayer, sound);
	}

	/// <summary>
	/// Gets the health percent of the fighter
	/// </summary>
	/// <value>The health percent.</value>
	public float HealthPercent
	{
		get 
		{
			//Returns the health percent from scale of 0 to 1
			return currentHealth/MAX_HEALTH;
		}
	}
		
	/// <summary>
	/// Gets the rigidbody of fighter
	/// </summary>
	/// <value>The body.</value>
	public Rigidbody body
	{
		get 
		{
			return this.rb;
		}
	}

	/// <summary>
	/// Calculates the distance to opponent.
	/// </summary>
	/// <returns>The distance to opponent.</returns>
    public float CalcDistanceToOpponent()
    {
        return Mathf.Abs(transform.position.x-opponent.transform.position.x);
    }

	/// <summary>
	/// Calculates the centre between the fighters
	/// </summary>
	/// <returns>The of game.</returns>
	public float CentreOfGame()
	{
		return (transform.position.x + opponent.transform.position.x) / 2;
	}

	/// <summary>
	/// Gets the user input
	/// </summary>
	public void UserInput()
	{
		//Sets the keyboard for user movement
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			animator.SetBool ("isForward", true);
		} 
		else if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			animator.SetBool ("isForward", false);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) 
		{
			animator.SetBool ("isBackward", true);
		} 
		else if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			animator.SetBool ("isBackward", false);
		}

		//Controls user movement
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			animator.SetBool ("isJump", true);
		} 
		else if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			animator.SetBool ("isJump", false);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			animator.SetBool ("isCrouch", true);
		} 
		else if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			animator.SetBool ("isCrouch", false);
		}

		//Sets keyboard input for defense
		if (Input.GetKeyDown (KeyCode.F)) 
		{
			animator.SetBool ("isDefend",true);
		}
		else if (Input.GetKeyUp(KeyCode.F))
		{
			animator.SetBool ("isDefend", false);
		}

		//Sets keyboard input for punches
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			animator.SetTrigger("isStraight");
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			animator.SetTrigger ("isLHook");
		}
			
			
		//Sets user input for kicks
		if (Input.GetKeyDown (KeyCode.X)) 
		{
			animator.SetTrigger ("isHighKick");
		}
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			animator.SetTrigger ("isSideKick");
		}
		if (Input.GetKeyDown (KeyCode.V)) 
		{
			animator.SetTrigger ("isSpecial");
		}
	}

    /// <summary>
    /// Gets the AI input
    /// </summary>
    public void AIInput()
    {

		//Sets and updates AI input
		animator.SetFloat("randomNum", random);
		animator.SetFloat("distanceToOpponent", CalcDistanceToOpponent());
		animator.SetBool("isOpponentAttacking", opponent.IsAttacking);
		animator.SetBool("isDamageVoid", IsVoidDamage);
        animator.SetBool("isDefend", IsDefending);

		//Enables AI fighter to move
        animator.SetBool("isEnable", enable);
 

		//Gets new value to random every second
        if (Time.time - randomSetTime > 1)
        {
            random = Random.value;
            randomSetTime = Time.time;
        }

    }
}
