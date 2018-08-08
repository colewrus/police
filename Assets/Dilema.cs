using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


[CommandInfo("Dilema",
             "First Test",
             "Testing")]

public class Dilema : Command {

	public override void OnEnter(){
		Debug.Log ("Test");
		Continue();
	}
}
