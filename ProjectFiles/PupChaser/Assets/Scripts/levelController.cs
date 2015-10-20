using UnityEngine;
using System.Collections;

public class levelController : MonoBehaviour {

	public GameObject goblin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.P)) {
			Instantiate(goblin, new Vector3(0, 19, 0), transform.rotation);
		}
	}
}
