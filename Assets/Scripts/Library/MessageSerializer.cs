using UnityEngine;
using System.Collections;
//For serializing
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MessageSerializer : MonoBehaviour {

	public static string Serialize(SerializableMessage message) {
		using(MemoryStream s = new MemoryStream()) {
			new BinaryFormatter().Serialize(s, message);
			return Convert.ToBase64String(s.ToArray());
		}
	}

	public static SerializableMessage Deserialize(string input) {
		using(MemoryStream s = new MemoryStream(Convert.FromBase64String(input))) { 
			BinaryFormatter bf = new BinaryFormatter();
			return (SerializableMessage)bf.Deserialize(s); 
		}
	}
}
