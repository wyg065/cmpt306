using UnityEngine;
using System.Collections;

public class AreaAttackScript : MonoBehaviour {

    //Variable used when destroying fireball
    public bool destroy;

    public bool atSpawn;

    public int direction;

    public float counter;

    //Script grabbed for position
    public PlayerController Player;

    // Use this for initialization

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "explosion(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "leaf(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "rock(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "fireBall(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "iceShard(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "lightning(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "spider web(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "weakAttack(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "mediumAttack(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "strongAttack(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "explosion(Clone)")
        {
            Player.invincible = true;
            Player.invincibilityCoolDown = 0.3f;
            Player.isCharge = true;
            Destroy(other.gameObject);
        }
    }

    void Start ()
    {
        destroy = false;
        counter = 0.3f;
        Player = FindObjectOfType<PlayerController>();
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        counter -= Time.deltaTime;
        this.transform.position = Player.charPosition;

        if(counter < 0)
        {
            destroy = true;
        }

        if (destroy == true)
        {
            Destroy(gameObject);
        }
    }
}
