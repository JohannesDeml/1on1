using UnityEngine;
using System.Collections;

public class FallingDownHandler : MonoBehaviour {

	
	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Bot") {
			other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			SpawnPointHandler.instance.SpawnObjectAtRandomPoint(other.gameObject);
		}
	}
}
