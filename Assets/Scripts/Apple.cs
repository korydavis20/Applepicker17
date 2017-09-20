﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

	public static float bottomY = -20f;
	

	// Update is called once per frame
	void Update () {
		if (transform.position.y < bottomY) {
			Destroy (this.gameObject);

			//get a reference to the applepicker component of main camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); //1

			//call public AppleDestroyed() method of apScript;
			apScript.AppleDestroyed();

		}

	}
}
