using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class High_Score : MonoBehaviour {

	static public int score = 1000;

	// Use this for initialization
	void Start () {
		
	}

	void Awake(){ //1
		//if the ApplePickerHighScore already exists, read it

		if(PlayerPrefs.HasKey("ApplePickerHighScore")){
			score = PlayerPrefs.GetInt ("ApplePickerHighScore"); //2
		}
		//assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score); //3
	}
	
	// Update is called once per frame
	void Update () {
		GUIText gt = this.GetComponent<GUIText> ();
		gt.text = "High Score: " + score;

		//update ApplePickerHighSCore in PlayerPrefs if necessary

		if (score > PlayerPrefs.GetInt ("ApplePickerHighScore")) { //4
			PlayerPrefs.SetInt ("ApplePickerHighScore", score);
		}
	}
}
