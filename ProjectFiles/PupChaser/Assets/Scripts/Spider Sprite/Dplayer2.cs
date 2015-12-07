using UnityEngine;
using System.Collections;

public class Dplayer2 : MonoBehaviour {

	public bool die ;
    public int health;
    public Rigidbody2D rb;
    public PlayerController Player;

	public int bounce ; 
	// Use this for initialization
	void Start () {
        health = 1;
		die = false;
        rb = GetComponent<Rigidbody2D>();
        Player = GetComponent<PlayerController>();
		bounce = 0; 
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
			bounce =  1 ; 
			/**
            Vector3 dir = (transform.position - Player.charPosition).normalized;
            dir *= Time.fixedDeltaTime * 40000f;
            rb.AddForce(dir * 1000);
            **/

        }
		if (other.gameObject.name == "ChargeAttack(Clone)")
		{
            health -=2; 
			bounce =  1 ; 
		}
		if(other.gameObject.name == "PlayerFireBall(Clone)")
        {
            health--;
			bounce =  1 ; 
            
        }
        if (other.gameObject.name == "ChargedFireBall(Clone)")
        {
            health--;
			bounce =  1 ; 
            
        }
        if (other.gameObject.name == "AreaAttackPrefab(Clone)")
        {
            health--;
			bounce =  1 ; 
           
        }

    }
}
