using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockLevel : MonoBehaviour {

	//This Method is for Alert the Player about clicking on Locked Level
	void Awake () {
		int gameLevel = Int32.Parse(this.gameObject.name);
		
		if(PlayerPrefs.GetInt("levelUnlock") >= gameLevel) {
			this.transform.Find("Lock").gameObject.SetActive(false);
			this.transform.Find("Text").gameObject.SetActive(true);
			GetComponent<Button>().interactable = true;
		} else {
			this.transform.Find("Text").gameObject.SetActive(false);
			this.transform.Find("star1").gameObject.SetActive(false);
			this.transform.Find("star2").gameObject.SetActive(false);
			this.transform.Find("star3").gameObject.SetActive(false);
		}
	}
}
