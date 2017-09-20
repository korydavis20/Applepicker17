using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	public Text scoreGT;

	// Use this for initialization
	void Start () {
		//find a reference to the scoreCounter GameObject
		GameObject scoreGO = GameObject.Find("Score Counter");
		//get the Text component of that GameObject
		scoreGT = scoreGO.GetComponent<Text>();
		//set the starting number of points to 0
		scoreGT.text = "0";
	}
	


	void Update () {
		
		// Get the current screen position of the mouse from input
		Vector3 mousePos2D = Input.mousePosition; //1

		// the camera's z position sets the how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z; //2

		//convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //3

		//move the x position of this basket to the x position of the mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;

	}

	void OnCollisionEnter(Collision coll){
		//find out what hit this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}

		//Parse the text of the scoreGT into an int
		int score = int.Parse(scoreGT.text);
		//Add points for catching the apple
		score += 100;
		//convert the score back to a string and display it
		scoreGT.text = score.ToString();

		//track high score
		if (score > High_Score.score) {
			High_Score.score = score;
		}
	}

}
