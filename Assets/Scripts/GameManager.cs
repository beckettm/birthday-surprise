using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject dad;
	public GameObject mom;
	public GameObject[] clueObjects;
	public Text introText;
	public Text clueText;
	public Text dialogText;
	public Text endText;
	public GameObject fade;
	public GameObject FullHouse;
	public GameObject ControlDisplay;

	public AudioSource music;
	public AudioSource correctSound;
	public AudioSource incorrectSound;
	public AudioSource recordScratchSound;
	
	public static bool isIntro = true;
	public static bool canMove = false;
	public static bool endGame = false;

	private int index = 0; //used to keep track of which object/clue the player has found
	private bool hasKey = false;


	void Start() {
		StartCoroutine(IntroCutscene());
	}

	void Update() {
		TurnToFacePlayer(dad);
		TurnToFacePlayer(mom);

		if (!isIntro) {

			// Displays clue text in quotes:
			if (!hasKey) {
				clueText.text = "\"" + AllText.clueOrder[index] + "\"";
			}

			// Handles the use of the Action key (Space) to search the house:
			if (Input.GetKeyUp(KeyCode.Space)) {
				if (Vector3.Distance (player.transform.position, clueObjects[index].transform.position) < 2f) {
					index++;

					DialogSpeak(index + 1);
					correctSound.Play();

					if (index >= 6) { //6, because clueObjects.Length doesn't work for some reason...
						hasKey = true;
						clueText.transform.parent.gameObject.SetActive(false);
						clueObjects[index].SetActive(false); //removes door once the key is obtained
					}

				} else {
					DialogNope();
					incorrectSound.Play();
				}
			}

			// End cutscene:
			if (endGame) {
				StartCoroutine(EndCutscene());
			}
		
		}
	}

	void TurnToFacePlayer(GameObject go) {
		Vector3 lookDir = player.transform.position - go.transform.position;
		lookDir.y = 0f;
		go.transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
	}

	private bool ActionIsPressed() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			return true;
		} else {
			return false;
		}
	}

	void DialogSpeak(int index) {
		dialogText.text = AllText.dialogOrder[index];
		Invoke("DialogDisappear", 4f);
	}

	void DialogNope() {
		dialogText.text = "There's nothing here...";
		Invoke("DialogDisappear", 2f);
	}

	void DialogDisappear() {
		dialogText.text = "";
	}


	/* COROUTINE CUTSCENES: */

	IEnumerator IntroCutscene() {
		CameraController.zoom = 20f;

		music.Play();
		music.loop = true;

		// Zooms in camera while increasing music volume:
		while (CameraController.zoom > 5f) {
			CameraController.zoom -= 0.2f;
			music.volume += 0.00062f;
			yield return new WaitForSeconds(0.01f);

			// Hides roof and exterior:
			if (CameraController.zoom <= 12f) {
				FullHouse.SetActive(false);
			}
		}
		yield return new WaitForSeconds(0.5f);
		introText.text = AllText.introText[0];

		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(ActionIsPressed);
		introText.text = AllText.introText[1];

		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(ActionIsPressed);
		introText.text = AllText.introText[2];

		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(ActionIsPressed);
		introText.text = "";
		dialogText.text = AllText.dialogOrder[0];

		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(ActionIsPressed);
		dialogText.text = AllText.dialogOrder[1];
		clueText.transform.parent.gameObject.SetActive(true);

		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(ActionIsPressed);
		dialogText.text = "";
		canMove = true;
		clueText.transform.parent.gameObject.SetActive(true);
		ControlDisplay.SetActive(true);

		yield return new WaitForSeconds(0.1f);
		isIntro = false;

		yield return new WaitForSeconds(7f);
		ControlDisplay.SetActive(false);
	}


	IEnumerator EndCutscene() {
		music.Stop();
		canMove = false;

		// Zooms camera out:
		while (CameraController.zoom < 11f) {
			CameraController.zoom += 0.0005f;
			yield return new WaitForSeconds(0.1f);
		}
		fade.gameObject.SetActive(true);

		yield return new WaitForSeconds(3f);
		endText.gameObject.SetActive(true);
	}

}