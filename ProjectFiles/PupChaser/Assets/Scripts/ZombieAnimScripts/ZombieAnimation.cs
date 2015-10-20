using UnityEngine;
using System.Collections;

public class ZombieAnimation : MonoBehaviour {

	public enemyController enemy;

	private Animator anim;

	private float y = 0;

	private float x = 0;

	// Use this for initialization
	void Start ()
	{
		enemy = FindObjectOfType<enemyController> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		y = Mathf.Abs (enemy.GetComponent<Rigidbody2D> ().velocity.y);
		x = Mathf.Abs (enemy.GetComponent<Rigidbody2D> ().velocity.x);

		if (y > x)
		{
			if (enemy.GetComponent<Rigidbody2D> ().velocity.y > 0)
			{
				anim.SetBool("moveUp", true);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveLeft", false);
				anim.SetBool("moveRight", false);
			}
			if (enemy.GetComponent<Rigidbody2D> ().velocity.y < 0)
			{
				anim.SetBool("moveDown", true);
				anim.SetBool("moveUp", false);
				anim.SetBool("moveLeft", false);
				anim.SetBool("moveRight", false);
			}
		}
		else
		{
			if (enemy.GetComponent<Rigidbody2D> ().velocity.x < 0)
			{
				anim.SetBool("moveLeft", true);
				anim.SetBool("moveUp", false);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveRight", false);
			}
			if (enemy.GetComponent<Rigidbody2D> ().velocity.x > 0)
			{
				anim.SetBool("moveRight", true);
				anim.SetBool("moveUp", false);
				anim.SetBool("moveDown", false);
				anim.SetBool("moveLeft", false);
			}
		}
	}
}
