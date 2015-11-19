using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject SnakePrefab ; 
	public GameObject GoblinPrefab ; 
	public GameObject SpiderPrefab ;
	public GameObject BerserkerPrefab ; 
	
	public GameObject spawnedenemy ; 

	public float SpawnRate = 0.05F ; 
	public float nextspawn = 0.05F ;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update ()
	{

		int a = Random.Range (1 , 18);

		if (Time.time > nextspawn) {
			
			nextspawn = Time.time + SpawnRate;

			if ((a == 1) || (a == 2) || (a == 3) || (a == 11)) {

				spawnedenemy = GameObject.Instantiate (SnakePrefab, transform.position, transform.rotation) as GameObject;
			
			} else if ((a == 4) || (a == 5) || (a == 6) || (a == 12)) {

				spawnedenemy = GameObject.Instantiate (GoblinPrefab, transform.position, transform.rotation) as GameObject;
			
			} else if ((a == 15) || (a == 16) || (a == 17) || (a == 7) || (a == 8) || (a == 13) || (a == 14)) {

				spawnedenemy = GameObject.Instantiate (SpiderPrefab, transform.position, transform.rotation) as GameObject;
			
			} else if ((a == 9) || (a == 10)) {
			
				spawnedenemy = GameObject.Instantiate (BerserkerPrefab, transform.position, transform.rotation) as GameObject;
			}

		}
	}
}
