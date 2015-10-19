using UnityEngine;
using System.Collections;

public class attackScript : MonoBehaviour {
	public PlayerController myScript;

	public GameObject slashSpawn;
	public GameObject slashPrefab;

	// Use this for initialization
	void Start () 
	{
		myScript = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(myScript.directionFacing == 1 && (myScript.attack == true))
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
