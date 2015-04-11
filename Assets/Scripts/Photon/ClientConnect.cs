using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClientConnect : MonoBehaviour {
	public Text startConnectionText;
	public Button startGameButton;
	private string connectionInformation;
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.2");
		startGameButton.interactable = false;
	}

	public void Update() {
		if(connectionInformation != PhotonNetwork.connectionState.ToString()) {
			connectionInformation = PhotonNetwork.connectionState.ToString();
			startConnectionText.text = connectionInformation;
		}
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom("TheRoom");
	}

	void OnJoinedRoom() {
		int photonId = PhotonNetwork.player.ID;
		Client.photonId = photonId;
		//Debug.Log(PhotonNetwork.playerList.Length);
		startGameButton.interactable = true;
	}
}
