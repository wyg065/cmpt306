using UnityEngine;
using System.Collections;

public class attackScript : MonoBehaviour {
    //Class to instantiate slash hitbox for the sword, will be separated later into a specific weapon.

    //We need the players direction facing
    public PlayerController myScript;
    
    //Clone variable
	public GameObject slashSpawn;

    public GameObject fireballSpawn;
    public GameObject fireballPrefab;
    //The slashprefab with collider size and sprite
    public GameObject slashPrefab;

    public GameObject chargeAttackSpawn;
    public GameObject chargeAttackPrefab;

	// Use this for initialization
	void Start () 
	{
		myScript = FindObjectOfType<PlayerController>();
	}
	

    void Update()
    {
        if (myScript.attack == true)
        {
            if (myScript.directionFacing == 1)
            {
                slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x + 0.5f, myScript.charPosition.y + 1.5f, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -90))) as GameObject;
            }
            if (myScript.directionFacing == 2)
            {
                slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x - 0.9f, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
            }
            if (myScript.directionFacing == 3)
            {
                slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y - 1.5f, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90))) as GameObject;
            }
            if (myScript.directionFacing == 4)
            {
                slashSpawn = Instantiate(slashPrefab, new Vector3(myScript.charPosition.x + 0.9f, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -180))) as GameObject;
            }
        }
        if(!myScript.canShoot)
        {
            if (myScript.directionFacing == 1)
            {
                fireballSpawn = Instantiate(fireballPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y + 1.5f, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 90))) as GameObject;
            }
            if (myScript.directionFacing == 2)
            {
                fireballSpawn = Instantiate(fireballPrefab, new Vector3(myScript.charPosition.x - 0.9f, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 180))) as GameObject;
            }
            if (myScript.directionFacing == 3)
            {
                fireballSpawn = Instantiate(fireballPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y - 1.5f, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, -90))) as GameObject;
            }
            if (myScript.directionFacing == 4)
            {
                fireballSpawn = Instantiate(fireballPrefab, new Vector3(myScript.charPosition.x + 0.9f, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
            }
        }
        if (myScript.chargeAttack == true)
        {
            if (myScript.directionFacing == 1)
            {
                chargeAttackSpawn = Instantiate(chargeAttackPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y + 1.0f, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
            }
            if (myScript.directionFacing == 2)
            {
                chargeAttackSpawn = Instantiate(chargeAttackPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
            }
            if (myScript.directionFacing == 3)
            {
                chargeAttackSpawn = Instantiate(chargeAttackPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
            }
            if (myScript.directionFacing == 4)
            {
                chargeAttackSpawn = Instantiate(chargeAttackPrefab, new Vector3(myScript.charPosition.x, myScript.charPosition.y, myScript.charPosition.z), Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, 0))) as GameObject;
            }
        }

    }
}
