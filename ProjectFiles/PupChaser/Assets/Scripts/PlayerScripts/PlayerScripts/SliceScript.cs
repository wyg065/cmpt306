using UnityEngine;
using System.Collections;

public class SliceScript : MonoBehaviour {

    public bool destroy;
    public PlayerController Player;

    IEnumerator waitinFunction(float delay)
    {
        yield return new WaitForSeconds(delay);
        destroy = true;
    }


    // Use this for initialization
    void Start ()
    {
	    destroy = false;
        Player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        transform.position = new Vector3(Player.charPosition.x, Player.charPosition.y, -10);

        if (destroy == false)
        {
            StartCoroutine(waitinFunction(0.8f));
        }
        if(destroy == true)
        {
            Destroy(gameObject);
        }

	}
}
