using UnityEngine;
using System.Collections;

public class TrailColor : MonoBehaviour {
	private TrailRenderer trail;
	private Color trailColor;
	// Use this for initialization
	void Start () {
		trail = GetComponent<TrailRenderer>();
		Color[] possibleColors = new Color[]{
			new Color(1.0f, 0.0f, 0.0f, 0.5f),
			new Color(1.0f, 0.0f, 1.0f, 0.5f),
			new Color(0.0f, 1.0f, 1.0f, 0.5f),
			new Color(1.0f, 1.0f, 0.0f, 0.5f),
			new Color(0.0f, 1.0f, 0.0f, 0.5f),
		};
		trail.material.SetColor("_TintColor", possibleColors[Random.Range(0, possibleColors.Length)]);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetNewTrailColor(Color newColor) {
		trail.material.SetColor("_TintColor", newColor);
	}
}
