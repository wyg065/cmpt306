using UnityEngine;
using System.Collections;

public class SliceScript : MonoBehaviour {
    //Variable used when destroying slice
    public bool destroy;

    //Script grabbed for position
    public PlayerController Player;

    //Wait function to destroy slice after delay
    IEnumerator waitinFunction(float delay)
    {
        yield return new WaitForSeconds(delay);
        destroy = true;
    }


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
        //Change position to chars position and quickly destroy hitbox
        transform.position = new Vector3(Player.charPosition.x, Player.charPosition.y, -10);

        if (destroy == false)
        {
            StartCoroutine(waitinFunction(0.2f));
        }
        if(destroy == true)
        {
            Destroy(gameObject);
        }

	}
}
