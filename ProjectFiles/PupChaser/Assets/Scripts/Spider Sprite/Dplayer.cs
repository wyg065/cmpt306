using UnityEngine;
using System.Collections;

public class Dplayer : MonoBehaviour {

	public  bool inrange ; 

	public  bool otherspiders  ; 

	public  bool otherber  ;

	public  bool othergoblin ; 

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

	void OnTriggerEnter2D (Collider2D othera )
	{
		if (othera.tag == "Player") {
			
			inrange = true; 

		} else if (othera.tag == "otherspiders") {
			
			otherspiders = true; 
			
		} else if (othera.tag == "Berserker") {

			otherber = true; 
		} else if (othera.tag == "goblin") {
			othergoblin = true ;
		}
	}


	void OnTriggerExit2D(Collider2D otherb)
	{
		if (otherb.tag == "Player") {
			
			inrange = false; 
		} else if (otherb.tag == "otherspiders") {
			
			otherspiders = false; 
			
		} else if (otherb.tag == "Berserker") {
			
			otherber = false; 
		}
		else if (otherb.tag == "goblin") {
			othergoblin = false ;
		}
	}

}
