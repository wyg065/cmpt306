using UnityEngine;
using System.Collections;

public class ChargeAttackScript : MonoBehaviour {
    //Variable used when destroying slice
    public bool destroy;

    //Script grabbed for position
    public PlayerController Player;

    public float time;

    // Use this for initialization
    void Start ()
    {
        //Initialize
        destroy = false;
        Player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        //transform.position = new Vector3(Player.charPosition.x, Player.charPosition.y, 0);
        
            if (Player.directionFacing == 1)
            {
                transform.position = new Vector3(Player.charPosition.x, Player.charPosition.y + 2.0f, 0);
            }
            if (Player.directionFacing == 2)
            {
                transform.position = new Vector3(Player.charPosition.x - 2.0f, Player.charPosition.y, 0);
            }
            if (Player.directionFacing == 3)
            {
                transform.position = new Vector3(Player.charPosition.x, Player.charPosition.y - 2.0f, 0);
            }
            if (Player.directionFacing == 4)
            {
                transform.position = new Vector3(Player.charPosition.x + 2.0f, Player.charPosition.y, 0);
            }
        
        if (time > 0.2)
        {
            destroy = true;
        }
        if (destroy == true)
        {
            Destroy(gameObject);
        }
    }
}
