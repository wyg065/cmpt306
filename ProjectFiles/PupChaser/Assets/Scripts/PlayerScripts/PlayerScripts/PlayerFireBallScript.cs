using UnityEngine;
using System.Collections;

public class PlayerFireBallScript : MonoBehaviour {

    //Variable used when destroying fireball
    public bool destroy;

    public bool atSpawn;

    public int direction;

    public float counter;

    //Script grabbed for position
    public PlayerController Player;

    public Rigidbody2D rBody;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collider")
        {
            destroy = true;
        }
        if (other.tag == "Berserker")
        {
            destroy = true;
        }
        if (other.tag == "spider")
        {
            destroy = true;
        }
        if (other.tag == "snake")
        {
            destroy = true;
        }
        if (other.tag == "goblin")
        {
            destroy = true;
        }
    }

    // Use this for initialization
    void Start ()
    {
        destroy = false;
        Player = FindObjectOfType<PlayerController>();
        rBody = FindObjectOfType<Rigidbody2D>();
        atSpawn = true;
        direction = Player.directionFacing;
        counter = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter += Time.deltaTime;
        if (atSpawn && direction == 1)
        {
            rBody.AddForce(Vector3.up * 1000);
            atSpawn = false;
        }
        if (atSpawn && direction == 2)
        {
            rBody.AddForce(Vector3.left * 1000);
            atSpawn = false;
        }
        if (atSpawn && direction == 3)
        {
            rBody.AddForce(Vector3.down * 1000);
            atSpawn = false;
        }
        if (atSpawn && direction == 4)
        {
            rBody.AddForce(Vector3.right * 1000);
            atSpawn = false;
        }
        if (destroy)
        {
            Destroy(gameObject);
        }
        if(Mathf.Abs(rBody.velocity.y) == 0 && Mathf.Abs(rBody.velocity.y) == 0 && counter > 1.0f)
        {
            destroy = true;
        }
	}
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
