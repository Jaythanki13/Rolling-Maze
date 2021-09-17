using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtonStars : MonoBehaviour {

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	void Start () {
		string currLevel = this.gameObject.name;		
		int numOfUnclockedStars = PlayerPrefs.GetInt("level" + currLevel + "Stars", 0);

		if(numOfUnclockedStars >= 1) {
			star1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
		}
		if(numOfUnclockedStars >= 2) {
			star2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
		}
		if(numOfUnclockedStars == 3) {
			star3.GetComponent<Image>().color = new Color(1, 1, 1, 1);
		}
	}
}
