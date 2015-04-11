using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class SwitchToGameMessage : SerializableMessage {
	
	public static readonly string NAME = "SwitchToGame";
	public float delay {get; private set;}

	public SwitchToGameMessage(float _delay)
		: base(NAME)
	{
		delay = _delay;
		base.Send();
	}
	
	public override string ToString() {
		return base.ToString() + "Go to game in " + delay + " seconds";
	}
}
