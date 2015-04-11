using UnityEngine;
using System.Collections;

public class SwitchLevel : MonoBehaviour {

	public void SwitchToGame() {
		new SwitchToGameMessage(0.01f);
	}

	public void SwitchToMenu() {
		new SwitchToMenuMessage(0.05f);
	}
}
