using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class creditsControler : MonoBehaviour {

	private float timer = 35.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+0.01f, transform.position.z);
		timer -= Time.deltaTime;
		if (timer < 0) {
			Application.LoadLevel("titleScren");
		}
	}
}
