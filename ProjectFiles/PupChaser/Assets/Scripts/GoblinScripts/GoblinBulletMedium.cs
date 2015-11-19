using UnityEngine;
using System.Collections;

public class GoblinBulletMedium : MonoBehaviour {

	private bool canChangeColour;

	// Use this for initialization
	void Start () {
		canChangeColour = true;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0, -20));
		if (canChangeColour)
		{
			GetComponent<SpriteRenderer>().color = Color.yellow;
			canChangeColour = false;
			StartCoroutine(waitForColour());
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//killBullet
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "wall") //(other.name != "weakAttack(Clone)" || other.name != "goblinEnemy")
		{
			Debug.Log ("destroy bullet");
			Destroy (this.gameObject, .2f);
		}
	}

	IEnumerator waitForColour()
	{
		yield return new WaitForSeconds (0.15f);
		canChangeColour = true;
	}
}
