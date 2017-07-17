using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	static SoundPlayer instance = null;

	void Awake() {
		// Destroys duplicate sound:
		if (instance != null) {
			Destroy (gameObject);
		// Prevents sound from ending upon loading of next scene:
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}