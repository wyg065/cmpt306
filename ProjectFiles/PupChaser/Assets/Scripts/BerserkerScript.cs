using UnityEngine;
using System.Collections;

public class BerserkerScript : MonoBehaviour
{
    public PlayerController Player;
    public Rigidbody2D rBody;
    public Animator anim;

    public float test;

    delegate void MyDelagate();
    MyDelagate beserkerAction;


    public int healthPoints;
    public float healthValue;


    //Function to handle collisions.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "")
        {
        }
    }
    // Use this for initialization
    void Start ()
    {
        Player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        test += Time.deltaTime;
        if (test > 0.0f)
        {
            rBody.AddForce(Vector3.up * 200);
        }
        if (test > 2.0f)
        {
            rBody.AddForce(Vector3.left * 200);
        }
        if (test > 4.0f)
        {
            rBody.AddForce(Vector3.down * 200);
        }
        if (test > 6.0f)
        {
            rBody.AddForce(Vector3.right * 200);
            test = 0.0f;
        }
    }
}
