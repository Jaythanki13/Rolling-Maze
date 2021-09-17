using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading;

public class LevelRotate : MonoBehaviour {

	public GameObject steeringWheel;
	private Rigidbody2D rb;

	private float zRot;
	private float angle;
	private float rotation = 0;
	private bool move = false;

	void Start() {
		rb = steeringWheel.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		if(move) {
			rb.MoveRotation((Mathf.LerpAngle(rb.rotation, rotation + zRot, 5 * Time.fixedDeltaTime)));
		}
	}


	public void OnPointerDown(BaseEventData data) {
		move = false;

		PointerEventData pointerData = data as PointerEventData;
		Vector3 levelPosition = Camera.main.WorldToScreenPoint (steeringWheel.transform.position);

		angle = Mathf.Atan2(levelPosition.x - pointerData.position.x, levelPosition.y - pointerData.position.y);
		zRot = steeringWheel.transform.eulerAngles.z - (Mathf.Rad2Deg * -angle);
	}

	public void RotateWheel(BaseEventData data) {
		move = true;

		PointerEventData pointerData = data as PointerEventData;
		Vector3 levelPosition = Camera.main.WorldToScreenPoint (steeringWheel.transform.position);

		angle = Mathf.Atan2(levelPosition.x - pointerData.position.x, levelPosition.y - pointerData.position.y);
		rotation = Mathf.Rad2Deg * -angle;
	}
}
