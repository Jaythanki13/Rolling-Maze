using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMenus : MonoBehaviour {

	//This is the Object of all the Game Object that is used while Creating Game Platform
	public GameObject LevelCompletedDialog;
	public GameObject PauseButton;
	public GameObject PauseMenu;
	private AudioSource buttonClickSound;
	public GameObject MainMenu;
	public GameObject LevelSelectMenu;
	public GameObject SoundOffImage;

	void Start() {
		//PlayerPrefs.DeleteAll();
		Application.targetFrameRate = 300;
		Vars.levelScore = 0;
		buttonClickSound = GameObject.Find("buttonClickSound").GetComponent<AudioSource>();

		if(SceneManager.GetActiveScene().name.Equals("mainMenu")) {
			if(AudioListener.volume == 1) {
			 	SoundOffImage.SetActive(false);
			}else{
				SoundOffImage.SetActive(true);
			}
		}
	}

	//Method to show Main Menu after Starting the Game
	public void ShowMainMenu() {
		buttonClickSound.Play();
		MainMenu.SetActive(true);
		LevelSelectMenu.SetActive(false);
	}

	//This is the code for Selecting Level after Main Menu
	public void ShowLevelSelectMenu() {
		buttonClickSound.Play();
		MainMenu.SetActive(false);
		LevelSelectMenu.SetActive(true);
	}

	//User will have the Option for Sound On or Off
	public void SoundOnOff() {
		if(AudioListener.volume == 1) {
			 AudioListener.volume = 0;
			 SoundOffImage.SetActive(true);
		}else{
			AudioListener.volume = 1;
			 SoundOffImage.SetActive(false);
		}
		buttonClickSound.Play();
	}

	//After clicking to the select Level Player will redirect to Game UI 
	public void LoadLevel() {
		buttonClickSound.Play();
		SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
	}
	//After successfully clearing the level User will jump onto next level
	public void NextLevel() {
		buttonClickSound.Play();
		string nextLevelNumber = (Int32.Parse(SceneManager.GetActiveScene().name) + 1).ToString();
		SceneManager.LoadScene(nextLevelNumber);
	}

	//This is the code for Exit to Main Menu from the Game
	public void ExitToMainMenu() {
		buttonClickSound.Play();
		Time.timeScale = 1;
		SceneManager.LoadScene("mainMenu");
	}

	//If Level get Completed then Popup will show Level completed with stars and rewards.
	public void LevelCompleted(float timer) {	
		Invoke("ShowLevelCompleteDialog", timer);
	}

	//This is the code for Level Complete Dialogue Box
	private void ShowLevelCompleteDialog() {
		LevelCompletedDialog.SetActive(true);
		PauseButton.SetActive(false);
		GameObject.Find("levelCompleteSound").GetComponent<AudioSource>().Play();
		GameObject.Find("Level").GetComponent<LevelRotate> ().enabled = false;
		Destroy(GameObject.Find("Balls"));

		int currLevel = Int32.Parse(SceneManager.GetActiveScene().name);

		if(PlayerPrefs.GetInt("levelUnlock", 0) < currLevel) {
			PlayerPrefs.SetInt("levelUnlock", currLevel + 1);
		}
		if(Vars.levelScore >= 200) {
			if(PlayerPrefs.GetInt("level" + currLevel + "Stars") == 0) {
				PlayerPrefs.SetInt("level" + currLevel + "Stars", 1);
			}
		}
		if(Vars.levelScore >= 500) {
			if(PlayerPrefs.GetInt("level" + currLevel + "Stars") < 2) {
				PlayerPrefs.SetInt("level" + currLevel + "Stars", 2);
			}
		}
		if(Vars.levelScore > 900) {
			PlayerPrefs.SetInt("level" + currLevel + "Stars", 3);
		}
		if(PlayerPrefs.GetInt("levelUnlock") <= currLevel) {
			PlayerPrefs.SetInt("levelUnlock", currLevel + 1);
		}
	}

	//Showing Pause Menu in the Game
	public void ShowPauseMenu() {
		GameObject.Find("pauseSound").GetComponent<AudioSource>().Play();
		PauseMenu.SetActive(true);
		PauseButton.SetActive(false);
		Time.timeScale = 0;
	}

	//If not in Use Pause Menu Kindly Hide that Button
	public void HidePauseMenu() {
		buttonClickSound.Play();
		PauseMenu.SetActive(false);
		PauseButton.SetActive(true);
		Time.timeScale = 1;
	}

	//Reply or Continue to Game
	public void Reply() {
		buttonClickSound.Play();
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//Exit or Quit Game Logic
	public void Exit() {
		buttonClickSound.Play();
		Application.Quit();
	}
}
