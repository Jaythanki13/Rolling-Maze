using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAnimation : MonoBehaviour {

	float scale = 1;
	float timer = 0;
	bool up = true;
	void Update () {
		timer += Time.deltaTime;
		if(timer >= 0.01f) {
			timer = 0;
			if(up) {
				scale += 0.002f;
				if(scale >= 1.1f){
					up = false;
				}
			}else {
				scale -= 0.002f;
				if(scale <= 1f) {
					up = true;
				}
			}
			GetComponent<RectTransform>().localScale = new Vector2(scale, scale);
			
		}
		
	}
}
