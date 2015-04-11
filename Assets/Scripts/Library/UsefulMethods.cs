using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsefulMethods : MonoBehaviour {

	private static string characters = "0123456789abcdefghijklmnopqrstuvwxABCDEFGHIJKLMNOPQRSTUVWXYZ";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static bool ChanceInPercent(float percent) {
		return (Random.Range(0.0f, 100.0f)<=percent);
	}

	public static string CreateRandomString(int length) {
		string code = "";
		
		for (int i = 0; i < length; i++) {
			int a = Random.Range(0, characters.Length);
			code = code + characters[a];
		}
		
		return code;
	}

	public static string BreakStringIntoLines(string text, int maxLineLength) {
		string newText = "";
		int lengthOfCurrentLine = 0;

		int pos = text.IndexOf(' ');
		while (pos >= 0)
		{
			if(lengthOfCurrentLine + pos <= maxLineLength) {
				lengthOfCurrentLine += pos;
				newText += text.Substring(0, pos);
			} else {
				newText += "\n" + text.Substring(0, pos);
				lengthOfCurrentLine = pos;
			}
			newText += " ";
			text = text.Substring(pos+1);
			pos = text.IndexOf(' ');
		}
		if(lengthOfCurrentLine + text.Length > maxLineLength) {
			newText += "\n";
		}
		newText += text;
		return newText;
	}

	public static string ConvertArrayToString<T>(IList<T> coll) {
		string output = "";
		foreach(T obj in coll) {
			try {
				output += obj.ToString();
			} catch {
				output += "Error";
			}
			output += ", ";
		}

		return output.Substring(0, output.Length - 2);
	}
}
