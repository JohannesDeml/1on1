using UnityEngine;
using System.Collections;

public class AmbientCameraManager : MonoBehaviour {
	private bool active = false;
	private Camera mainCamera;
	void Start() {
		mainCamera = Camera.main;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)) {
			active = !active;
			if(active) {
				GetComponent<AmbientCamera>().Activate();
				mainCamera.enabled = false;
			} else {
				mainCamera.enabled = true;
				Debug.Log("Blub");
				GetComponent<AmbientCamera>().DeactivateAll();
			}
		}
	}
}
