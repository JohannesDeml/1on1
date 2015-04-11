using UnityEngine;
using System.Collections;

public class DestroyItselfIn : MonoBehaviour {
	public float seconds;
	// Use this for initialization
	void Start () {
		Invoke("DestroyIn", seconds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void DestroyIn() {
		Destroy(gameObject);
	}
}
