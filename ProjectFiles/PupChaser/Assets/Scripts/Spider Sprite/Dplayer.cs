using UnityEngine;
using System.Collections;

public class Dplayer : MonoBehaviour {

	public static bool inrange ; 

	public static bool otherspiders  ; 

	public static bool otherber  ;

	public static bool othergoblin ; 

	// Use this for initialization
	void Start () {

		inrange = false;
		otherspiders = false; 
		otherber = false;
		othergoblin = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.tag == "Player") {
			
			inrange = true; 

		} else if (other.tag == "otherspiders") {
			
			otherspiders = true; 
			
		} else if (other.tag == "Berserker") {

			otherber = true; 
		} else if (other.tag == "goblin") {
			othergoblin = true ;
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			
			inrange = false; 
		} else if (other.tag == "otherspiders") {
			
			otherspiders = false; 
			
		} else if (other.tag == "Berserker") {
			
			otherber = false; 
		}
		else if (other.tag == "goblin") {
			othergoblin = false ;
		}
	}

}
