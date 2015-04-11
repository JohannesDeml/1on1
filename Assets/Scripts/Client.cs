using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Client : MonoBehaviour {
	public static PhotonView photonView;
	public static int photonId;
	public GameObject player;

	// Use this for initialization
	void Start () {
		Messenger.instance.SubscribeTo(SwitchToGameMessage.NAME, gameObject);
		photonView = transform.GetComponent<PhotonView>();
		photonId = PhotonNetwork.player.ID;
	}

	public void StartGame() {
		Debug.Log(photonId);
		player = PhotonNetwork.Instantiate("Player", new Vector3(0.0f, -100.0f, 0.0f), Quaternion.identity, 0);
		SpawnPointHandler.instance.SpawnObjectAtRandomPoint(player);
		Camera.main.GetComponent<LookAt>().SetTarget(player.transform);
		player.SetActive(true);
		player.GetComponent<PlayerInput>().moveable = true;
		player.AddComponent<PlayerCollisionHandler>();
	}

	public void EndGame() {
		Application.Quit();
	}
}
