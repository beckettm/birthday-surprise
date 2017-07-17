using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public static float zoom = 5f;

	private Vector3 offset;


	void Start() {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate() {
		transform.position = player.transform.position + offset;

		Camera.main.orthographicSize = zoom;
	}
}