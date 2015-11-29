using UnityEngine;
using System.Collections;

public class Dplayer2 : MonoBehaviour {

	public bool die ;

	// Use this for initialization
	void Start () {
	
		die = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.gameObject.name == "Slice(Clone)") {
			
			die = true ;  
		}
		if (other.gameObject.name == "ChargeAttack(Clone)")
		{
			
			die = true ; 
		}
		
		
	}
}
