using UnityEngine;
using System.Collections;

public class detectplayer : MonoBehaviour {

	public  bool inrange ; 

	// Use this for initialization
	void Start () {
	
		inrange = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D othera )
	{
		if (othera.tag == "Player") {
			
			inrange = true; 
			
		} 

	}
}
