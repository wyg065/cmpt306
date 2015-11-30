using UnityEngine;
using System.Collections;

public class cagescript : MonoBehaviour {

	public GameObject healthBar;
	private GameObject snakeHealthBar;

	public float barSize ;

	public int health ; 

	//loads health bar, and gives reference tho that specific health bar a.k.a snakeHelathBar


	// Use this for initialization
	void Start () {
	
		health = 50; 
		snakeHealthBar = (GameObject)Instantiate (healthBar, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
		updateHealthBar ();
	}

	void updateHealthBar() {
		barSize = health * 10; 
		snakeHealthBar.transform.localScale = new Vector3(barSize, 3, 0);
	}
	
	// Update is called once per frame
	void Update () {
		updateHealthBar ();
	}


	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.gameObject.name == "Slice(Clone)") {
			
			health--; 

		}
		if (other.gameObject.name == "ChargeAttack(Clone)")
		{
			
			health = health - 3  ;
		}
		
		
	}
}
