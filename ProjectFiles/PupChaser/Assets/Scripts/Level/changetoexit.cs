using UnityEngine;
using System.Collections;

public class changetoexit : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other )
	{
		if (other.tag == "Player") {
			Application.LoadLevel("finalLevel") ; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
