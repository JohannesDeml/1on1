using UnityEngine;
using System.Collections;

public class NumberToStringFormatter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static string Format(float number, int decimalPrecision) {
		if(number <999.5f) {
			if(decimalPrecision == 0) {
				return Mathf.RoundToInt(number).ToString();
			}
			
			string stringFormat = "{0:0.";
			for(int i = 0; i<decimalPrecision; i++) {
				stringFormat += "0";
			}
			stringFormat += "}";
			return string.Format(stringFormat, number);
		}
		//Thousand
		if(number < 999999.5f) {
			if(number < 99999.5f) {
				float kNumber = Mathf.Round(number/100.0f)/10.0f;
				return string.Format("{0:0.0K}", kNumber);
			} else {
				float kNumber = Mathf.Round(number/1000.0f);
				return string.Format("{0:0K}", kNumber);
			}
		}
		//Million
		if(number < 999999999.5f) {
			if(number < 99999999.5f) {
				float kNumber = Mathf.Round(number/100000.0f)/10.0f;
				return string.Format("{0:0.0M}", kNumber);
			} else {
				float kNumber = Mathf.Round(number/1000000.0f);
				return string.Format("{0:0M}", kNumber);
			}
		}
		//For everything else
		return "a lot";
	}
}
