using UnityEngine;
using System.Collections;

public class AmbientCamera : MonoBehaviour {
	public AmbientCamera nextCamera;
	private float switchingTime = 5.0f;
	// Use this for initialization
	void Start () {
	
	}

	public void Activate() {
		GetComponent<Camera>().enabled = true;
		Invoke("SwitchCamera", switchingTime);
	}

	public void Deactivate() {
		CancelInvoke();
		GetComponent<Camera>().enabled = false;
	}

	public void DeactivateAll() {
		CancelInvoke();
		if(GetComponent<Camera>().enabled == true) {
			GetComponent<Camera>().enabled = false;
		} else {
			nextCamera.DeactivateAll();
		}

	}

	public void SwitchCamera() {
		nextCamera.Activate();
		Deactivate();
	}
}
