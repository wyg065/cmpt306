using UnityEngine;
using System.Collections;

public class dungeonSpawnController : MonoBehaviour {

	public GameObject[] spawners;
	private GameObject player;

 
	private GameObject currentSpawner;

	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("spawner");
		player = GameObject.FindWithTag("Player");
		if (spawners.Length > 0) {
			print ("success, there are "+spawners.Length+" spawners");
 
			currentSpawner = findClosestToPlayer();

			print (currentSpawner);

			stopAllSpawnersExceptOne(currentSpawner);
			//currentSpawner.GetComponent<SpawnEnemies>().currentDifficulty = 10;
		} else {
			print ("failure");
		}
	}

	void FixedUpdate() {
		if (spawners.Length > 0) {
			print ("success, there are "+spawners.Length+" spawners");

			currentSpawner = findClosestToPlayer();
			stopAllSpawnersExceptOne(currentSpawner);
			//currentSpawner.GetComponent<SpawnEnemies>().currentDifficulty = 10;
		} else {
			print ("failure");
		}
	}

	GameObject findClosestToPlayer() {
		float temp = Mathf.Infinity;
		GameObject closest = spawners[0];

		for (int i = 0; i < spawners.Length; i++) {
			if(Mathf.Abs(Vector3.Distance(player.transform.position, spawners[i].transform.position)) < temp && Vector3.Distance(player.transform.position, spawners[i].transform.position) > 20)
            {
				temp = Vector3.Distance(player.transform.position, spawners[i].transform.position);
				closest = spawners[i];
			}
		}

		return closest;
	}
 

	void stopAllSpawnersExceptOne(GameObject s) {
		for (int i = 0; i < spawners.Length; i++) {
			if (spawners[i] != s) {
				spawners[i].GetComponent<SpawnEnemies>().enabled = false;
			}
			if (spawners[i] == s) {
				spawners[i].GetComponent<SpawnEnemies>().enabled = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
