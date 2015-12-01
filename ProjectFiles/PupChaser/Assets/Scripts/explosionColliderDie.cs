using UnityEngine;
using System.Collections;

public class explosionColliderDie : MonoBehaviour {


	public float timer;

	// Use this for initialization
	void Start ()
	{
		timer = 1.5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer -= Time.deltaTime;
		if (timer < 0)
		{
			Destroy(this.gameObject);
		}
	}

}
