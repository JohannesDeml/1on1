using UnityEngine;
using System.Collections;

public class SocialScripts : MonoBehaviour {

	public void OpenWebsite(string website) {
		Application.OpenURL(website);
	}
}
