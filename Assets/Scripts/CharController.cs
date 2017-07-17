using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	public float moveSpeed = 7f;

	Vector3 forward, right;

	void Start() {
		// Sets directional vectors to equate to orthographic camera vectors:
		forward = Camera.main.transform.forward;
		forward.y = 0;
		forward = Vector3.Normalize(forward);
		right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
	}
	
	void FixedUpdate() {
		if(Input.anyKey && GameManager.canMove) {
			Move();
		}
	}

	void Move() {
		// Gets Input:
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

		// Defines direction of movement:
		Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

		// Makes movement happen:
		transform.forward = heading; //rotates player to always face direction of movement
		transform.position += rightMovement;
		transform.position += upMovement;
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "End Trigger") {
			GameManager.endGame = true;
		}
	}
}
