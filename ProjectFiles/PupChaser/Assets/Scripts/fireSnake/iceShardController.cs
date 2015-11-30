using UnityEngine;
using System.Collections;

public class iceShardController : MonoBehaviour {

	private float seekTime = 0.2f;
	private float seekTimer = 0.0f;
	
	private float timeBeforeSeek = 0.25f;
	private float timeBeforeSeekTimer = 0.0f;
	
	// Use this for initialization
	void Start () {
		seekTimer = seekTime;
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
	}
	
	// Update is called once per frame
	void Update () {
		timeBeforeSeekTimer -= Time.deltaTime;
		if (timeBeforeSeekTimer < 0) {
			seekTimer -= Time.deltaTime;
		}
		seekTimer -= Time.deltaTime;
		
		var angle = 0.0f;
		
		if ((seekTimer > 0) && (timeBeforeSeekTimer < 0)) {
			GetComponent<Rigidbody2D> ().AddRelativeForce (Vector3.right * 26);
			
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
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
		GetComponent<Rigidbody2D>().AddRelativeForce (Vector3.right * 26);
	}
	
	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
