using UnityEngine;
using System.Collections;

public class shootweb3 : MonoBehaviour {
	
	
	public GameObject webPrefab ; 
	public GameObject spawnedweb1 ; 
	public GameObject spawnedweb2 ;
	public GameObject spawnedweb3 ;
	
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
				spawnedweb1 = GameObject.Instantiate(webPrefab ,  transform.position , transform.rotation) as GameObject  ; 
				spawnedweb2 = GameObject.Instantiate(webPrefab ,  transform.position , transform.rotation) as GameObject  ; 
				spawnedweb3 = GameObject.Instantiate(webPrefab ,  transform.position , transform.rotation) as GameObject  ;

				spawnedweb1.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(900 , -2000 )) ; 
				spawnedweb2.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-900 , -2000 )) ;
				spawnedweb3.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0 , -2000 )) ;




				temp = 1 ;
				StartCoroutine(Example());
				Destroy (spawnedweb1, 2);
				Destroy (spawnedweb2, 2);
				Destroy (spawnedweb3, 2);
			}
			
			
		}
		
	}
	
	IEnumerator Example() {
		yield return new WaitForSeconds(3);
		temp = 0;
	}
	
}
