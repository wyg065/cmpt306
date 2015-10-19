using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	public float attackCooldown;
	public bool attack;
	public Rigidbody2D rBody;
    public float walkSpeed;
	public int directionFacing;
   
	public Animator playerAnimation;

	public Vector3 charPosition;

    // Use this for initialization
	void Start ()
    {
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
        charPosition = transform.position;
		attackCooldown -= Time.deltaTime;

		//Checking if the character is moving or not.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            playerAnimation.SetBool("isMoving", true);
        }
        else
        {
            playerAnimation.SetBool("isMoving", false);
        }
        
		if (Input.GetKeyDown(KeyCode.Space) && (attackCooldown <= 0.0f)) 
		{
			playerAnimation.SetBool ("Attack", true);
			attack = true;
			attackCooldown =0.5f;
		} 
		else 
		{
			playerAnimation.SetBool ("Attack", false);	
			attack = false;

		}

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
