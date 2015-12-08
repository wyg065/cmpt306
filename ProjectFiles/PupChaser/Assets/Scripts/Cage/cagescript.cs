using UnityEngine;
using System.Collections;

public class cagescript : MonoBehaviour {

	public GameObject healthBar;
	private GameObject snakeHealthBar;

	public float barSize ;

	public int health ; 

	private Animator anim;

	private bigbosscontrol ec  ;

	private bool b ; 

	//loads health bar, and gives reference tho that specific health bar a.k.a snakeHelathBar

	GameObject[] gameObjects;

	public GameObject webPrefab ; 
	public GameObject spawnedweb ;

	// Use this for initialization
	void Start () {
	
		b = false;
		health = 100; 
		snakeHealthBar = (GameObject)Instantiate (healthBar, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
		updateHealthBar ();

		anim = GetComponent<Animator> ();
		ec = GetComponent<bigbosscontrol>(); 

	}

	void updateHealthBar() {
		barSize = health * 10; 
		snakeHealthBar.transform.localScale = new Vector3(barSize, 3, 0);
	}
	
	// Update is called once per frame
	void Update () {
		updateHealthBar ();

		if (health < 0 ) {

			bigbossanimation.ec.enabled = false ; 
			bigbossanimation.anim.SetBool("Die", true);

			gameObjects = GameObject.FindGameObjectsWithTag ("spawner");
			
			for(var i = 0 ; i < gameObjects.Length ; i ++)
			{
				Destroy(gameObjects[i]);
			}

			gameObjects = GameObject.FindGameObjectsWithTag ("spider");
			
			for(var i = 0 ; i < gameObjects.Length ; i ++)
			{
				Destroy(gameObjects[i]);
			}

			gameObjects = GameObject.FindGameObjectsWithTag ("goblin");
			
			for(var i = 0 ; i < gameObjects.Length ; i ++)
			{
				Destroy(gameObjects[i]);
			}

			gameObjects = GameObject.FindGameObjectsWithTag ("snake");
			
			for(var i = 0 ; i < gameObjects.Length ; i ++)
			{
				Destroy(gameObjects[i]);
			}

			gameObjects = GameObject.FindGameObjectsWithTag ("Berserker");
			
			for(var i = 0 ; i < gameObjects.Length ; i ++)
			{
				Destroy(gameObjects[i]);
			}

			gameObjects = GameObject.FindGameObjectsWithTag ("tempspikes");
			
			for(var i = 0 ; i < gameObjects.Length ; i ++)
			{
				Destroy(gameObjects[i]);
			}

			/**
			anim.SetBool("Die", true);
			ec.enabled = false ;
			**/

			if (b== false )
			{
				spawnedweb = GameObject.Instantiate(webPrefab ,  transform.position , transform.rotation) as GameObject  ;
				b =true  ;
				Destroy(gameObject);
			}


		}
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
