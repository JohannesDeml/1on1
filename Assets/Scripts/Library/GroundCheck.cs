using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
	public PlayerInput listenerScript;
	private int groundLayerId;

	public void Start() {
		groundLayerId = LayerMask.NameToLayer("Ground");
	}

	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == groundLayerId) {
			listenerScript._OnTouchGround();
		}
	}
}
