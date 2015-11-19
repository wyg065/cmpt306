using UnityEngine;
using System.Collections;

public class explosionColliderDie : MonoBehaviour {
	
	GoblinAI goblin;

	// Use this for initialization
	void Start () {
		//timeToDie = false;
		goblin = FindObjectOfType<GoblinAI> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (goblin.timeToDie)
		{
			Destroy (this.gameObject);
		}
	
	}
}
