using UnityEngine;
using System.Collections;

public class EndGameListener : MonoBehaviour {
	public GameObject screenWon;
	public GameObject screenLost;

	void Update() {
		if(Input.GetKeyDown(KeyCode.R)) {
			screenWon.SetActive(false);
			screenLost.SetActive(false);
		}
	}

	// Use this for initialization
	void Start () {
		Messenger.instance.SubscribeTo(GameWonMessage.NAME, gameObject);
		Messenger.instance.SubscribeTo(GameLostMessage.NAME, gameObject);
	}

	public void _GameWon(GameWonMessage message) {
		screenWon.SetActive(true);
	}

	public void _GameLost(GameLostMessage message) {
		screenLost.SetActive(true);
	}
}
