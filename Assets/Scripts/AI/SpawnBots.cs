using UnityEngine;
using System.Collections;

public class SpawnBots : MonoBehaviour {
	private GameObject botPrefab;
	private GameObject fakingBot;
	// Use this for initialization
	void Start () {
		botPrefab = (GameObject)Resources.Load("Bot");
		fakingBot = (GameObject)Resources.Load("FakingBot");

		InvokeRepeating("SpawnBot", 20.0f, 15.0f);
		InvokeRepeating("SpwanFakingBot", 40.0f, 15.0f);
	}

	public void SpawnBot() {
		GameObject bot = (GameObject)GameObject.Instantiate(botPrefab, new Vector3(0.0f, -100.0f, 0.0f), Quaternion.identity);
		bot.transform.SetParent(transform, true);
		SpawnPointHandler.instance.SpawnObjectAtRandomPoint(bot);
	}

	public void SpwanFakingBot() {
		GameObject bot = (GameObject)GameObject.Instantiate(fakingBot, new Vector3(0.0f, -100.0f, 0.0f), Quaternion.identity);
		bot.transform.SetParent(transform, true);
		SpawnPointHandler.instance.SpawnObjectAtRandomPoint(bot);
	}
}
