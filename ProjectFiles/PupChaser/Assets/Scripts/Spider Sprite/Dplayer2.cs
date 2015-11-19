using UnityEngine;
using System.Collections;

public class Dplayer2 : MonoBehaviour {

	public static bool inrange ;

	// Use this for initialization
	void Start () {
	
		inrange = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.tag == "Player") {
			
			inrange = true; 
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			
			inrange = false; 
		}
	}
}
