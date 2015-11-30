using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {

	public GameObject webPrefab ; 
	public GameObject spawnedweb ; 

	private GameObject player ; 

	public float fireRate = 2000F ; 
	public float nextfire = 200F ;

	public bool test ;
	

	// Use this for initialization
	void Start () {

		test = false; 
		player = GameObject.FindWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (detectplayer.inrange == false) {
			test = false;
		
		}

		if (Time.time > nextfire )
		{
			nextfire = Time.time + fireRate;
			spawnedweb = GameObject.Instantiate(webPrefab ,  transform.position , transform.rotation) as GameObject  ; 
			//spawnedweb.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0 , -1200 )) ; 
			//StartCoroutine(Example());
			Destroy (spawnedweb, 1);

			if(detectplayer.inrange == true)
			{
				//player.GetComponent<Rigidbody2D>().AddForce();

				if (player.transform.position.y > 13)
				{
					player.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0 , 400));
				}
				else
				{
					player.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0 , -400));
				}
			}
		}
	
	}

	IEnumerator Example() {
		yield return new WaitForSeconds(3);
	}
}
