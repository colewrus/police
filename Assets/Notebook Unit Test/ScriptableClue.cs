using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Clue", menuName ="clue", order =1)]

public class ScriptableClue : ScriptableObject {

    
    public string clueName;
    public string Description;
    public bool found;
    public string clueText;

    public ScriptableClue clueBuddy;

    [Tooltip("the clue that this clue spawns when combined with buddy")]
    public ScriptableClue clueSpawn; //the clue that results from combine with buddy
    public bool connected; //has this clue already found the buddy


	

}
