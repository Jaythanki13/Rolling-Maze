using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour {

	public GameObject score;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name.Equals("LevelEndCollider")) {
			Vars.levelScore += 100;
			score.SetActive(true);
			score.transform.parent = null;
			score.transform.rotation = Quaternion.Euler(0, 0, 0);
			Destroy(score, 2.5f);
			GameObject.Find("popSound").GetComponent<AudioSource> ().Play();
			Destroy(this.gameObject);
		}
    }
}
