using UnityEngine;
using System.Collections;

public class sliderController : MonoBehaviour {

	public Camera cam;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
		
		GetComponent<RectTransform>().localPosition = new Vector3 (-width*25,height*25,0);
		//gameObject.GetComponent<RectTransform> ().position = new Vector3 (0,0,0);
	}
}
