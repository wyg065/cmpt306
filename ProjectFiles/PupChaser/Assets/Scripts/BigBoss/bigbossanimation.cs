using UnityEngine;
using System.Collections;

public class bigbossanimation : MonoBehaviour {

	
	//create an enemyController variable called enemy
	public GoblinController enemy;
	
	//animator for the goblin enemy
	public static Animator anim;
	
	//variable to store the absolute value of goblin's y velocity
	private float y = 0;
	
	//variable to store the absolute value of goblin's x velocity
	private float x = 0;

	public int health =  80 ; 
	
	public static bigbosscontrol ec  ;

	 

	// Use this for initialization
	void Start ()
	{
		//find enemyController and assign it to enemy
		enemy = FindObjectOfType<GoblinController> ();

		//find the animator
		anim = GetComponent<Animator> ();

		ec = GetComponent<bigbosscontrol>(); 

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (health < 0) {
			anim.SetBool("Die", true);

			ec.enabled = false;

		}

		//the absolute value of the enemy's y velocity
		y = Mathf.Abs (enemy.GetComponent<Rigidbody2D> ().velocity.y);
		//the absolute value of the enemy's x velocity
		x = Mathf.Abs (enemy.GetComponent<Rigidbody2D> ().velocity.x);
		
		//because the enemy could be moving left, right, and up or down we need a way to decide
		//which animation to play. Therefore whichever is greater velocity, the animation for that
		//direction will be played.  This is the reasoning for finding the absolute value of x and y
		//velocity.
		
		//if its time to detonate, then detonate animation.

		//If y is greater than x, play y animation
		if (y > x)
		{
			//if y velocity is positive
			if (enemy.GetComponent<Rigidbody2D> ().velocity.y > 0)
			{
				//set the move up boolean value to true
				anim.SetBool("moveUp", true);
				//set all other values to false
				anim.SetBool("moveDown", false);
				anim.SetBool("moveLeft", false);
				anim.SetBool("moveRight", false);

			}
			//if the y velocity is negative
			if (enemy.GetComponent<Rigidbody2D> ().velocity.y < 0)
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
			if (enemy.GetComponent<Rigidbody2D> ().velocity.x < 0)
			{
				//set the move left boolean value to true
				anim.SetBool("moveLeft", true);
				//set all other values to false
				anim.SetBool("moveUp", false);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveRight", false);

			}
			//if the x velocity is positive
			if (enemy.GetComponent<Rigidbody2D> ().velocity.x > 0)
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

	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.gameObject.name == "Slice(Clone)") {
			
			health -- ;   
		}
		if (other.gameObject.name == "ChargeAttack(Clone)")
		{
			
			health = health -3 ; 
		}
		if(other.gameObject.name == "PlayerFireBall(Clone)")
		{
			health-- ; 
		}
		
	}
}
