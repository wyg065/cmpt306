using UnityEngine;
using System.Collections;

public class BerserkerScript : MonoBehaviour {
    public Vector3 targetPlayer;
    public Vector3 targetSpawn;
    public PlayerController Player;
    public Rigidbody2D rBody;
    public Animator anim;

    delegate void MyDelagate();
    MyDelagate beserkerAction;


    public int healthPoints;
    public float zombieSpeed;


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
	void Update () {
	
	}
}
