using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the Code for Level End
public class LevelEnd : MonoBehaviour {

	int numberOfBalls = 0;
	void Start() {
		GameObject[] allBalls = GameObject.FindGameObjectsWithTag("ball");
		numberOfBalls = allBalls.Length;
	}

	//When Game Object will Get in connection then On Trigger method will call and get executed
	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name.Contains("Ball")) {
			Destroy(col.gameObject, 2f);
			GameObject.Find("GameManager").GetComponent<LevelEndTimer> ().enabled = true;
			numberOfBalls--;
			if(numberOfBalls <= 0 ) {
				GameObject.Find("GameManager").GetComponent<LevelEndTimer> ().enabled = false;
				GameObject.Find("GameManager").GetComponent<GameMenus> ().LevelCompleted(0.5f); 
				if(GameObject.Find("LevelEndTimer") != null) {
					GameObject.Find("LevelEndTimer").SetActive(false);
				}
			}
		}
    }
}
