using UnityEngine;
using System.Collections;

public class leafController : MonoBehaviour {
	private float spinTime = 0.4f;
	private float spinTimer = 0.2f;
	private bool oneWay = false;
	private bool firstRun = true;

	private GameObject target;

	// Use this for initialization
	void Start () {
		target = gameObject;
		var playerPos = GameObject.FindWithTag ("Player").GetComponent<Rigidbody2D> ().transform.position;
		var x = playerPos.x - transform.position.x;
		var y = playerPos.y - transform.position.y;
		if (Mathf.Abs (x) > Mathf.Abs (y)) {
			if (x > 0) {
				transform.Rotate(0, 0, 0);
			} else {
				transform.Rotate(0, 0, 180);
			}
		} else {
			if (y > 0) {
				transform.Rotate(0, 0, 90);
			} else {
				transform.Rotate(0, 0, 270);
			}
		}

		GameObject enemy = GameObject.FindWithTag ("Player");
		float yPos = enemy.GetComponent<Rigidbody2D> ().transform.position.y - transform.position.y;
		float xPos = enemy.GetComponent<Rigidbody2D> ().transform.position.x - transform.position.x;
		var angle = Mathf.Atan2 (yPos, xPos) * Mathf.Rad2Deg;
		
		while (angle > 360) {
			angle -= 360;
		}
		while (angle < 0) {
			angle += 360;
		}
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	public void setTarget(GameObject t) {
		target = t;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy(gameObject);
		}	
		if (col.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}
		if(col.gameObject.name == "Slice(Clone)")
		{
			Destroy(gameObject);
		}
		if (col.gameObject.name == "PlayerFireBall(Clone)") {
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "collider") {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//makes shots more accurate, due to spawning
		//from the player, the direction it goes
		//first will be slightly favored.
		if (firstRun) {
			GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.right * 5);
		} else {
			GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.right * 20);
		}

		spinTimer -= Time.deltaTime;
		if (spinTimer < 0) {
			if (firstRun) {
				firstRun = false;
			}
			spinTimer = spinTime;
			if (oneWay) {
				oneWay = false;
			} else {
				oneWay = true;
			}
		}
		if (oneWay) {
			transform.RotateAround (target.transform.position, Vector3.forward, 500.0f * Time.deltaTime);
		} else {
			transform.RotateAround (target.transform.position, Vector3.forward, -500.0f * Time.deltaTime);
		}
	}
	
	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
