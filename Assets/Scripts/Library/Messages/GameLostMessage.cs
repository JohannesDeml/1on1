using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GameLostMessage : SerializableMessage {
	
	public static readonly string NAME = "GameLost";
	public float delay {get; private set;}
	
	public GameLostMessage(float _delay)
		: base(NAME)
	{
		delay = _delay;
		base.Send();
	}
	
	public override string ToString() {
		return base.ToString() + "GameLostMessage: " + delay + " seconds";
	}
}
