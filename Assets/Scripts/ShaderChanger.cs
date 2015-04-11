using UnityEngine;
using System.Collections;

public class ShaderChanger : MonoBehaviour {
	public Color colorStart = Color.red;
	public Color colorEnd = Color.green;
	public float duration = 100.0f;
	public Material groundMaterial;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		groundMaterial.color = Color.Lerp(colorStart, colorEnd, lerp);
	}
}
