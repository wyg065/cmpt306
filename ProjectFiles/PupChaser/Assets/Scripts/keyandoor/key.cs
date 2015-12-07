using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {

	GameObject[] gameObjects1;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Character")
		{

			gameObjects1 = GameObject.FindGameObjectsWithTag ("exitdoor");
			
			for(var i = 0 ; i < gameObjects1.Length ; i ++)
			{
				Destroy(gameObjects1[i]);
			}


			Destroy(gameObject);


		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
