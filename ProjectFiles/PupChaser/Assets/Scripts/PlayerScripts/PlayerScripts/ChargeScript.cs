using UnityEngine;
using System.Collections;

public class ChargeScript : MonoBehaviour {
    //Script of player to follow
    public PlayerController Player;

    // Use this for initialization
    void Start ()
    {
        Player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(Player.charPosition.x, Player.charPosition.y+0.3f, 0);
        if (Player.isCharge)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }


    }
}
