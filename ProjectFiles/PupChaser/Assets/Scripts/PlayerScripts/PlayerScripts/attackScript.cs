using UnityEngine;
using System.Collections;

public class attackScript : MonoBehaviour {
    //Class to instantiate slash hitbox for the sword, will be separated later into a specific weapon.

    //We need the players direction facing
    public PlayerController myScript;
    
    //Clone variable
	public GameObject slashSpawn;

    //The slashprefab with collider size and sprite
    public GameObject slashPrefab;

	// Use this for initialization
	void Start () 
	{
		myScript = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Checking variables in player script that tell us direction facing and if they have inputted an attack
        //Decides rotation of sprite and instantiates prefab.
        //Directions: Up = 1, Left = 2, Down = 3, Right = 4
        if (myScript.directionFacing == 1 && (myScript.attack == true))
		{
			slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x+0.5f, myScript.charPosition.y+1.5f, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -90)))as GameObject;
		}
		if(myScript.directionFacing == 2 && (myScript.attack == true))
		{
            slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x - 0.9f, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
        }
		if(myScript.directionFacing == 3 && (myScript.attack == true))
		{
            slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y - 1.5f, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90))) as GameObject;
        }
		if(myScript.directionFacing == 4 && (myScript.attack == true))
		{
            slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x + 0.9f, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -180))) as GameObject;
        }
	}
}
