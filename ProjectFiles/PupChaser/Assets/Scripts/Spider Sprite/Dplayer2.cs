using UnityEngine;
using System.Collections;

public class Dplayer2 : MonoBehaviour {

	public bool die ;
    public int health;
    public Rigidbody2D rb;
    public PlayerController Player;
	// Use this for initialization
	void Start () {
        health = 2;
		die = false;
        rb = GetComponent<Rigidbody2D>();
        Player = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(health < 1)
        {
            die = true;
        }
	}
    

	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.gameObject.name == "Slice(Clone)") {
			
			health-- ;
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 40000f;
            rb.AddForce(dir * 1000);
        }
		if (other.gameObject.name == "ChargeAttack(Clone)")
		{
            health -=2; 
		}
		if(other.gameObject.name == "PlayerFireBall(Clone)")
        {
            health--;
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 40000f;
            rb.AddForce(dir);
        }
        if (other.gameObject.name == "ChargedFireBall(Clone)")
        {
            health--;
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 40000f;
            rb.AddForce(dir);
        }
        if (other.gameObject.name == "AreaAttackPrefab(Clone)")
        {
            health--;
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 40000f;
            rb.AddForce(dir);
        }

    }
}
