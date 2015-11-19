using UnityEngine;
using System.Collections;

public class SpiderAnimation : MonoBehaviour {

	public GameObject enemy ;
	public Transform looker;

	public int speed ; 

	float angle  ; 
	
	
	// Use this for initialization
	void Start () {

		angle = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		GameObject enemy = GameObject.FindWithTag ("Player");

		float yPos = enemy.GetComponent<Rigidbody2D> ().transform.position.y - transform.position.y;
		float xPos = enemy.GetComponent<Rigidbody2D> ().transform.position.x - transform.position.x;
		angle = Mathf.Atan2 (yPos, xPos) * Mathf.Rad2Deg;
		
		while (angle > 360) {
			angle -= 360;
		}
		while (angle < 0) {
			angle += 360;
		}
		angle += 90; 
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

	}
}

