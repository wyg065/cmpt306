﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tutorialController : MonoBehaviour {

	public Text pressKeyText;

	private float flashTime = 0.3f;
	private float flashTimer;

	// Use this for initialization
	void Start () {
		flashTimer = flashTime;
	}
	
	// Update is called once per frame
	void Update () {
		flashTimer -= Time.deltaTime;
		if (flashTimer < 0) {
			flashTimer = flashTime;
			if (pressKeyText.text == "") {
				pressKeyText.text = "press any button to continue";
			} else {
				pressKeyText.text = "";
			}
		}
		if (Input.anyKey) {
			Application.LoadLevel("Level2");
		}
	}
}
