using UnityEngine;
using System.Collections;

public class PupAnimation : MonoBehaviour {

	public PupController puppy;

	//animator for the pup
	private Animator anim;
	
	//variable to store the absolute value of pup's y velocity
	private float y = 0;
	
	//variable to store the absolute value of pup's x velocity
	private float x = 0;

	// Use this for initialization
	void Start ()
	{
		puppy = FindObjectOfType<PupController> ();

		//find the animator
		anim = GetComponent<Animator> ();
	}
	

	// Update is called once per frame
	void Update ()
	{
		//the absolute value of the enemy's y velocity
		y = Mathf.Abs (puppy.GetComponent<Rigidbody2D> ().velocity.y);
		//the absolute value of the enemy's x velocity
		x = Mathf.Abs (puppy.GetComponent<Rigidbody2D> ().velocity.x);
		
		//because the enemy could be moving left, right, and up or down we need a way to decide
		//which animation to play. Therefore whichever is greater velocity, the animation for that
		//direction will be played.  This is the reasoning for finding the absolute value of x and y
		//velocity.

		//If y is greater than x, play y animation
		if (y > x)
		{
			//if y velocity is positive
			if (puppy.GetComponent<Rigidbody2D> ().velocity.y > 0)
			{
				//set the move up boolean value to true
				anim.SetBool("moveUp", true);
				//set all other values to false
				anim.SetBool("moveDown", false);
				anim.SetBool("moveLeft", false);
				anim.SetBool("moveRight", false);
			}
			//if the y velocity is negative
			if (puppy.GetComponent<Rigidbody2D> ().velocity.y < 0)
			{
				//set the move down boolean value to true
				anim.SetBool("moveDown", true);
				//set all other values to false
				anim.SetBool("moveUp", false);
				anim.SetBool("moveLeft", false);
				anim.SetBool("moveRight", false);
			}
		}
		//otherwise if x is less than y, play x animation.
		else
		{
			//if the x velocity is negative
			if (puppy.GetComponent<Rigidbody2D> ().velocity.x < 0)
			{
				//set the move left boolean value to true
				anim.SetBool("moveLeft", true);
				//set all other values to false
				anim.SetBool("moveUp", false);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveRight", false);
			}
			//if the x velocity is positive
			if (puppy.GetComponent<Rigidbody2D> ().velocity.x > 0)
			{
				//set the move right boolean value to true
				anim.SetBool("moveRight", true);
				//set all other values to false
				anim.SetBool("moveUp", false);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveLeft", false);
			}
		}
	}
}
