using UnityEngine;
using System.Collections;

public class changetoboxx : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.tag == "Player") {
			
			Application.LoadLevel("bossRoom1") ; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
