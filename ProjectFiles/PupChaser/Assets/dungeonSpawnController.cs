using UnityEngine;
using System.Collections;

public class dungeonSpawnController : MonoBehaviour {

	public GameObject[] spawners;
	private GameObject player;

<<<<<<< HEAD
	private GameObject currentSpawner;

=======
>>>>>>> origin/wyattBranch3
	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("spawner");
		player = GameObject.FindWithTag("Player");
		if (spawners.Length > 0) {
			print ("success, there are "+spawners.Length+" spawners");
<<<<<<< HEAD
			currentSpawner = findClosestToPlayer();
			stopAllSpawnersExceptOne(currentSpawner);
			currentSpawner.GetComponent<SpawnEnemies>().currentDifficulty = 10;
		} else {
			print ("failure");
		}
	}

	void FixedUpdate() {
		spawners = GameObject.FindGameObjectsWithTag("spawner");
		player = GameObject.FindWithTag("Player");
		if (spawners.Length > 0) {
			print ("success, there are "+spawners.Length+" spawners");
			currentSpawner = findClosestToPlayer();
			stopAllSpawnersExceptOne(currentSpawner);
			currentSpawner.GetComponent<SpawnEnemies>().currentDifficulty = 10;
=======
			print(findClosestToPlayer().transform.position);
>>>>>>> origin/wyattBranch3
		} else {
			print ("failure");
		}
	}

	GameObject findClosestToPlayer() {
		float temp = Mathf.Infinity;
		GameObject closest = spawners[0];

		for (int i = 0; i < spawners.Length; i++) {
			if(Mathf.Abs(Vector3.Distance(player.transform.position, spawners[i].transform.position)) < temp){
				temp = Vector3.Distance(player.transform.position, spawners[i].transform.position);
				closest = spawners[i];
			}
		}

		return closest;
	}
<<<<<<< HEAD

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
=======
>>>>>>> origin/wyattBranch3
	
	// Update is called once per frame
	void Update () {
	
	}
}
