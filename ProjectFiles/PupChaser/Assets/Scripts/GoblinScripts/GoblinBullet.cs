using UnityEngine;
using System.Collections;

public class GoblinBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0, -20));
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//killBullet
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "collider" || other.gameObject.name == "Slice(Clone)" || other.gameObject.name == "ChargeAttack(Clone)") //(other.name != "weakAttack(Clone)" || other.name != "goblinEnemy")
		{
			Debug.Log ("destroy bullet");
			Destroy (this.gameObject, .2f);
		}
	}
}
