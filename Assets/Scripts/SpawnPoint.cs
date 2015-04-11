using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<SpawnPointHandler>().AddSpawnPoint(this);
	}
	
	public void SpawnObject(GameObject newObject) {
		newObject.transform.position = transform.position;
		newObject.transform.rotation = transform.rotation;
	}
}
