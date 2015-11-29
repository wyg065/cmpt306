using UnityEngine;
using System.Collections;

public class dungeonSpawnController : MonoBehaviour {

	public GameObject[] spawners;
	private GameObject player;

	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("spawner");
		player = GameObject.FindWithTag("Player");
		if (spawners.Length > 0) {
			print ("success, there are "+spawners.Length+" spawners");
			print(findClosestToPlayer().transform.position);
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
