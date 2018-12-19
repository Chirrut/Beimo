using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStateBehaviour : StateMachineBehaviour 
{
	//Stores the forces acted on fighter 
	public float horizontalForce;
	public float verticalForce;

	//Stores the state that the fighter is in
    public FighterState behaviourState;

	//Stores the fighter in question
	protected Fighter fighter;

	//Stores the sound effect clip for the particular state
	public AudioClip soundEffect;

	 //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{

		//Assigns who is going to be the fighter if fighter stored is null
		if (fighter == null) 
		{
			fighter = animator.gameObject.GetComponent<Fighter> ();
		}

        fighter.currentState = behaviourState;

		//Adds force on the fighter to the vertical plane(i.e. jump)
		fighter.body.AddForce(new Vector3(0f,verticalForce,0f));

		//Plays the sound effect of associated fighter state
		if (soundEffect != null) 
		{
			fighter.PlaySoundEffect (soundEffect);
		}

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{

		//Adds force to the fighter on the horizontal plane
		fighter.body.AddForce(new Vector3(horizontalForce,0f,0f));
	

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
