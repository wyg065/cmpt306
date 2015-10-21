using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

    //Attack cooldown for character, might want to change this system later, not sure if there is a better way.
	public float attackCooldown;

    //Bool used for attack scripts and cooldowns
    public bool attack;


    public Rigidbody2D rBody;

    //Movement speed of character
    public float walkSpeed;

    //Global variable useful for other scipts to be able to tell your direction
    //Directions: Up = 1, Left = 2, Down = 3, Right = 4
    public int directionFacing;
   
    //Character animator
	public Animator playerAnimation;

    //Global variable of character position
	public Vector3 charPosition;

    // Use this for initialization
	void Start ()
    {
        //Get components and initialize variables
        rBody = GetComponent<Rigidbody2D>();
        charPosition = transform.position;

        playerAnimation = GetComponent<Animator>();
        playerAnimation.SetBool("isMoving", false);
		playerAnimation.SetBool ("Attack", false);
		playerAnimation.SetInteger("DirectionFacing", 3);
		attackCooldown = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update character position for other scripts
        charPosition = transform.position;

        //Lower attack cooldown. Is there a better  way for this?
        attackCooldown -= Time.deltaTime;

		//Checking if the character is moving or not, used for moving and idle animations
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnimation.SetBool("isMoving", true);
        }
        else
        {
            playerAnimation.SetBool("isMoving", false);
        }
        
        //Statement used to check if attack has been input, if so we tell the animator, update our global variable and reset the cooldown
		if (Input.GetKeyDown(KeyCode.Space) && (attackCooldown <= 0.0f)) 
		{
			playerAnimation.SetBool ("Attack", true);
			attack = true;
			attackCooldown =0.5f;
		}
        //Letting the animator know that we arent attacking.
        else 
		{
			playerAnimation.SetBool ("Attack", false);	
			attack = false;

		}

        //Moving Player in all directions. We update the direction facing, add our force, and let our animator know what direction we are facing. For side walking I flip the image.
        //Directions: Up = 1, Left = 2, Down = 3, Right = 4

        //Move Player Up
        if (Input.GetKey(KeyCode.W))
        {
            rBody.AddForce(Vector3.up * walkSpeed);
            playerAnimation.SetInteger("DirectionFacing", 1);
			directionFacing = 1;
        }

        //Move Player Left
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            rBody.AddForce(Vector3.left * walkSpeed);
            playerAnimation.SetInteger("DirectionFacing", 2);
			directionFacing = 2;
        }

        //Move Player Down
        if (Input.GetKey(KeyCode.S))
        {
            rBody.AddForce(Vector3.down * walkSpeed);
            playerAnimation.SetInteger("DirectionFacing", 3);
			directionFacing = 3;
        }

        //Move Player Right
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
            }
            
            rBody.AddForce(Vector3.right * walkSpeed);
            playerAnimation.SetInteger("DirectionFacing", 4);
			directionFacing = 4;

        }
    }
}
