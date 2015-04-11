using UnityEngine;
using System.Collections;

public class RemoteProcedureCalls : MonoBehaviour {

	[RPC]
	public void ThrowItem(int throwingPlayer, int receivingPlayer, int item) {
		Debug.Log ("The item " + item + " was thrown from " + throwingPlayer + " to " + receivingPlayer);
	}	
}
