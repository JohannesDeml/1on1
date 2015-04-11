using UnityEngine;
using System.Collections;

public class PlayerCollisionHandler : MonoBehaviour {
	public bool gameOver = false;

	void Update() {
		if(Input.GetKeyDown(KeyCode.R)) {
			gameOver = false;
		}
	}
	void OnCollisionEnter(Collision collision) {
		if(!gameOver) {
			string otherTag = collision.gameObject.tag;
			if(otherTag == "Bot") {
				gameOver = true;
				Debug.Log("Collided with bot, you suck!");
				new GameLostMessage(0.0f);
			} else if(otherTag == "Player") {
				gameOver = true;
				Debug.Log("Collided with player, you win!");
				new GameWonMessage(0.0f);
			}
		}
	}
}
