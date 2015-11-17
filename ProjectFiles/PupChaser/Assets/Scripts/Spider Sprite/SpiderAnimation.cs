using UnityEngine;
using System.Collections;

public class SpiderAnimation : MonoBehaviour {

	public Transform target;
	public Transform looker;

	public int speed ; 
	
	
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 vectorToTarget = target.position - looker.position;
		float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		looker.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * speed);

	}
}

