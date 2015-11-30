using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {

	public GameObject webPrefab ; 
	public GameObject spawnedweb ; 

	public float fireRate = 2000F ; 
	public float nextfire = 200F ;

	public bool test ;

	detectplayer d ;

	// Use this for initialization
	void Start () {

		test = false; 
		d = GetComponentInChildren<detectplayer> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextfire )
		{
			nextfire = Time.time + fireRate;
			spawnedweb = GameObject.Instantiate(webPrefab ,  transform.position , transform.rotation) as GameObject  ; 
			//spawnedweb.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0 , -1200 )) ; 
			//StartCoroutine(Example());
			Destroy (spawnedweb, 1);
			if(d.inrange == true )
			{
				test = true  ; 
			}
		}
	
	}

	IEnumerator Example() {
		yield return new WaitForSeconds(3);
	}
}
