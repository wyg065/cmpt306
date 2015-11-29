using UnityEngine;
using System.Collections;

public class shootweb : MonoBehaviour {

	 
	public GameObject webPrefab ; 
	public GameObject spawnedweb ; 

	public float fireRate = 200F ; 
	public float nextfire = 200F ;

	public int  temp = 0 ; 
	Dplayer dd ;
	


	// Use this for initialization
	void Start () {

		dd = GetComponentInChildren<Dplayer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (dd.inrange == true) {

			if ((Time.time > nextfire )&&(temp == 0))
			{
				nextfire = Time.time + fireRate;
				spawnedweb = GameObject.Instantiate(webPrefab ,  transform.position , transform.rotation) as GameObject  ; 
				spawnedweb.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0 , -1200 )) ; 
				temp = 1 ;
				StartCoroutine(Example());
				Destroy (spawnedweb, 1);
			}


		}

	}

	IEnumerator Example() {
		yield return new WaitForSeconds(3);
		temp = 0;
	}
	
}
