using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour {

	public GameObject	basketPrefab;
	public int	numBaskets = 3;
	public float	basketBottomY = -14f;
	public float	basketSpacingY = 2f;
	public List<GameObject> basketList;

	void Start () {
		basketList = new List<GameObject> ();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}
	
	public void AppleDestroyed(){	// 2
		//destroy all of the falling apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);

			//restart the game, which doesn't affect High_Score.score
			if (basketList.Count == 0) {
				Application.LoadLevel ("Scene_0");
			}
		}

		//destroy one of the baskets
		//get the index of the last basket in basketList
		int basketIndex = basketList.Count-1;
		//get a reference to that basket GameObject
		GameObject tBasketGo = basketList[basketIndex];
		//remove the basket from the list and destroy the game object
		basketList.RemoveAt(basketIndex);
		Destroy (tBasketGo);
	}

	void Update () {
		
	}
}
