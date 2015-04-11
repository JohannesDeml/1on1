using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class SwitchToMenuMessage : SerializableMessage {
	
	public static readonly string NAME = "SwitchToMenu";
	public float delay {get; private set;}
	
	public SwitchToMenuMessage(float _delay)
		: base(NAME)
	{
		delay = _delay;
		base.Send();
	}
	
	public override string ToString() {
		return base.ToString() + "Go to menu in " + delay + " seconds";
	}
}
