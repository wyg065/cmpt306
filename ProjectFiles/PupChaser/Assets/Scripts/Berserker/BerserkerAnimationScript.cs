using UnityEngine;
using System.Collections;

public class BerserkerAnimationScript : MonoBehaviour {
    public BerserkerScript berserker;
    private Animator anim;
    private float y = 0;
    private float x = 0;

    // Use this for initialization
    void Start () {
        //find enemyController and assign it to enemy
        berserker = FindObjectOfType<BerserkerScript>();

        //find the animator
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        y = Mathf.Abs(berserker.GetComponent<Rigidbody2D>().velocity.y);
        x = Mathf.Abs(berserker.GetComponent<Rigidbody2D>().velocity.x);

        if (y > x)
        {
            //if y velocity is positive
            if (berserker.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                //set the move up boolean value to true
                anim.SetBool("moveUp", true);
                //set all other values to false
                anim.SetBool("moveDown", false);
                anim.SetBool("moveLeft", false);
                anim.SetBool("moveRight", false);
            }
            //if the y velocity is negative
            if (berserker.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                //set the move down boolean value to true
                anim.SetBool("moveDown", true);
                //set all other values to false
                anim.SetBool("moveUp", false);
                anim.SetBool("moveLeft", false);
                anim.SetBool("moveRight", false);
            }
        }
        else
        {
            //if the x velocity is negative
            if (berserker.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                //set the move left boolean value to true
                anim.SetBool("moveLeft", true);
                //set all other values to false
                anim.SetBool("moveUp", false);
                anim.SetBool("moveDown", false);
                anim.SetBool("moveRight", false);
            }
            //if the x velocity is positive
            if (berserker.GetComponent<Rigidbody2D>().velocity.x > 0)
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


