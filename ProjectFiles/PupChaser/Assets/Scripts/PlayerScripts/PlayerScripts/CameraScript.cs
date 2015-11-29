using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    //Script of player to follow
    public PlayerController Player;
    
    // Use this for initialization
    void Start ()
    {
        //Get object to follow
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move camera with global character position variable and sit high up on layer -10
        //transform.position =  new Vector3 (Player.charPosition.x, Player.charPosition.y, -10);

		//iTween.MoveUpdate(gameObject,new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z), 1.75f);
    }
	 void FixedUpdate() {
		iTween.MoveUpdate(gameObject,new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z), 1.75f);
	}
}
