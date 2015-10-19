using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public PlayerController Player;
    
    // Use this for initialization
    void Start ()
    {
        Player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Player.charPosition;
        transform.position =  new Vector3 (Player.charPosition.x, Player.charPosition.y, -10);
    }

}
