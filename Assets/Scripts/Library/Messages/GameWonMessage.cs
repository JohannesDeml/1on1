using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GameWonMessage : SerializableMessage {
	
	public static readonly string NAME = "GameWon";
	public float delay {get; private set;}
	
	public GameWonMessage(float _delay)
		: base(NAME)
	{
		delay = _delay;
		base.Send();
	}
	
	public override string ToString() {
		return base.ToString() + "GameWonMessage: " + delay + " seconds";
	}
}
