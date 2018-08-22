using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Clue", menuName ="clue", order =1)]

public class ScriptableClue : ScriptableObject {


    public string clueName;
    public bool found;
    public string clueText;

    public string clueBuddy; //what other clue does this partner with?
    public ScriptableClue clueBuddy2;

    public ScriptableClue clueSpawn; //the clue that results from combine with buddy
    public bool connected; //has this clue already found the buddy

	// Use this for initialization
	void Start () {

	}
	

}
