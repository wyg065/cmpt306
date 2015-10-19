using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {


    public Rigidbody2D rBody;
    public float walkSpeed;
    public float maxSpeed;
   
    public Animator directionFacing;
    public Animator isMoving;
    public Vector3 charPosition;
    

    // Use this for initialization
	void Start ()
    {
        rBody = GetComponent<Rigidbody2D>();
        charPosition = transform.position;

        isMoving = GetComponent<Animator>();
        directionFacing = GetComponent<Animator>();
        isMoving.SetBool("isMoving", false);
        directionFacing.SetInteger("DirectionFacing", 3);
    }
	
	// Update is called once per frame
	void Update ()
    {
        charPosition = transform.position;
        //Checking if the character is moving or not.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving.SetBool("isMoving", true);
        }
        else
        {
            isMoving.SetBool("isMoving", false);
        }
        
        //Move Player Up
        if (Input.GetKey(KeyCode.W))
        {
            rBody.AddForce(Vector3.up * walkSpeed);
            directionFacing.SetInteger("DirectionFacing", 1);
        }

        //Move Player Left
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }

            rBody.AddForce(Vector3.left * walkSpeed);
            directionFacing.SetInteger("DirectionFacing", 2);
        }

        //Move Player Down
        if (Input.GetKey(KeyCode.S))
        {
            rBody.AddForce(Vector3.down * walkSpeed);
            directionFacing.SetInteger("DirectionFacing", 3);
        }

        //Move Player Right
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
            }
            
            rBody.AddForce(Vector3.right * walkSpeed);
            directionFacing.SetInteger("DirectionFacing", 4);

        }
    }
}
