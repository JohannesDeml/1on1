using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPointHandler : MonoBehaviour {
	private List<SpawnPoint> spawnPoints;
	public static SpawnPointHandler instance;
	void Awake () {
		spawnPoints = new List<SpawnPoint>();
		instance = this;
	}
	
	public void AddSpawnPoint(SpawnPoint newSpawnPoint) {
		spawnPoints.Add(newSpawnPoint);
	}

	public void SpawnObjectAtRandomPoint(GameObject newObject) {
		spawnPoints[Random.Range(0, spawnPoints.Count)].SpawnObject(newObject);
	} 
}
