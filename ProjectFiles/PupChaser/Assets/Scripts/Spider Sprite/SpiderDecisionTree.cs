using UnityEngine;
using System.Collections;

public class SpiderDecisionTree : MonoBehaviour {

	private enemyControllerspider ec  ; 
	private shootweb sw  ;
	private Animator anim ; 
	private shootweb3 sw3 ; 

	int i ; 

	Dplayer2 d ; 
	Dplayer dd ;

	public GameObject healthBar;
	private GameObject snakeHealthBar;

	public GameObject heartPrefab;
	Vector3 dir ; 

	private Rigidbody2D rb ;
	private PlayerController Player ;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Player = GetComponent<PlayerController>();

		d = GetComponentInChildren<Dplayer2> ();
		dd = GetComponentInChildren<Dplayer> ();

		ec = GetComponent<enemyControllerspider>(); 
		sw = GetComponent<shootweb>();
		anim = GetComponent<Animator> ();
		sw3 = GetComponent<shootweb3> ();

		int a = Random.Range (1 , 7);    

		if ((a == 1) || (a == 4)) {
		
			rapidattack ();

		} else if ((a == 2) || (a == 5)) {

			shootweb (); 

		} else if ((a == 3) || (a == 6)) {

			bothattacks ();
		} else if (a == 7) {
			shootweb3() ; 
		}

		//loads health bar, and gives reference tho that specific health bar a.k.a snakeHelathBar
		snakeHealthBar = (GameObject)Instantiate (healthBar, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
		updateHealthBar ();
	}

	void updateHealthBar() {
		float barSize = 150;
		snakeHealthBar.transform.localScale = new Vector3(barSize, 3, 0);
	}

	void rapidattack ()
	{
		ec.enabled = true;
		anim.SetBool ("Moving", false);
	}

	void shootweb() 
	{
		sw.enabled = true; 
	}

	void bothattacks() 
	{
		ec.enabled = true; 
		sw.enabled = true; 
	}

	void shootweb3()
	{
		sw3.enabled = true; 
		transform.localScale += new Vector3(5, 5, 0);

	}


	// Update is called once per frame
	void Update () {

		snakeHealthBar.transform.position = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
	

		if (dd.otherspiders == true) {
			ec.enabled = true; 
		} else if (dd.otherber == true) {

			sw.enabled = true; 
			ec.enabled = true; 
		}
		else if (dd.othergoblin == true)
		{
			sw.enabled = true; 
			ec.enabled = true; 
		}
		if (d.die == true) {

			Destroy(this.gameObject);
			Destroy (snakeHealthBar);

			i = Random.Range(1, 100);
			
			if(i < 10)
			{
				GameObject spawnedenemy = GameObject.Instantiate(heartPrefab, transform.position, transform.rotation) as GameObject;
			}

		}

	}


}
