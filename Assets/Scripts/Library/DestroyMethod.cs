using UnityEngine;
using System.Collections;

public class DestroyMethod : MonoBehaviour {

	public void DestroyNow() {
		Debug.Log("Blub");
		Destroy(gameObject);
	}
}
