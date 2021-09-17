using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarFrame : MonoBehaviour {

	private float timer = 0;
	float alpha = 0;
	float scale;
	bool up = true;

	public GameObject starFrame;

	void Start() {
		scale = GetComponent<Transform>().localScale.x;
	}

	void Update () {
		timer += Time.deltaTime;
		if(timer >= 0.03f) {
			timer = 0;
			if(up) {
				alpha += 0.1f;
				scale += 0.01f;
				if(alpha >= 1f) {
					up = false;
				}
			}else {
				alpha -= 0.1f;
				scale -= 0.01f;
				if(alpha <= -1f) {
					Destroy(this.gameObject);
				}
			}
			
			starFrame.GetComponent<Image> ().color = new Color(1, 1, 1, alpha);
			starFrame.GetComponent<Transform> ().localScale =  new Vector3(scale, scale, 1);
		}		
	}
}
