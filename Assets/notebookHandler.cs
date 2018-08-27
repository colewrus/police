using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;



public static class ExtensionMethod
{
    public static bool clueOverlap(this RectTransform recT1, RectTransform recT2)
    {
        Rect clueT1 = new Rect(recT1.localPosition.x, recT1.localPosition.y, recT1.rect.width, recT1.rect.height);
        Rect clueT2 = new Rect(recT2.localPosition.x, recT2.localPosition.y, recT2.rect.width, recT2.rect.height);

        return clueT1.Overlaps(clueT2);
    }
}

//should make a clue class and then hold a # of clue objects in a list. 
//Will need some way to manage the panel space on the notebook with all the clues
//i.e. if 2 text & 3 picture clues 

public class notebookHandler : MonoBehaviour {

    public bool NotebookActive;
    public Canvas OverlayCanvas;
    public GameObject NotebookObj;  //the UI panel of the notebook;
    public GameObject NotebookButton; //for animation stuph


    public Flowchart notebookFlow;

    public GameObject selectedClue;

    //UI elements in the notebook. A set amount. Use gameobject for rectoverlap 
    public List<GameObject> clueElements = new List<GameObject>();

    //temporary list to just hold clues
    public List<ScriptableClue> GatheredClues = new List<ScriptableClue>();

    //bool to show object is hoveirng. Used to manage the actual combination of clues
    bool currentClueHover; 

	// Use this for initialization
	void Start () {
        NotebookObj.SetActive(false);
        currentClueHover = false;
	}
	
	// Update is called once per frame
	void Update () {

        //if player has selected a clue from the notebook
        //should this be a while?
        if(selectedClue != null){
            selectedClue.transform.position = Input.mousePosition;

            for (int i = 0; i < clueElements.Count; i++)
            {
                if( selectedClue == clueElements[i]){

                }else if(selectedClue.GetComponent<RectTransform>().clueOverlap(clueElements[i].GetComponent<RectTransform>())){
                    //hovering
                    if (clueElements[i].GetComponent<ClueDisplay>().myClue == selectedClue.GetComponent<ClueDisplay>().myClue.clueBuddy2){
                        currentClueHover = true;
                        selectedClue.GetComponent<ClueDisplay>().HoverHighlight();
                    }

                    break;

                }else{
                    currentClueHover = false;
                    selectedClue.GetComponent<ClueDisplay>().ResetColor();
                }
            }

        }
		
	}


    public void AddClue_Animation(){
        NotebookButton.GetComponent<Animator>().SetTrigger("T_clueAdd");
    }


    //This guy should be in a more genearl game manager. But maybe this is enough
    public void EnableOverlay(){
        OverlayCanvas.gameObject.SetActive(true);
        NotebookObj.SetActive(false);
    }

    public void DisableOverlay(){
        OverlayCanvas.gameObject.SetActive(false);
    }

    //opens the notebook panel
    //need to have some better way to gate the update above to lighten load
    public void NoteBookButton(){
        Debug.Log("Notebook button");
        //need to setup toggle
        if(!NotebookActive){
            NotebookActive = true;
            NotebookObj.SetActive(true);
            selectedClue = null;
            //set the text on the clues
            RefreshClues();
            //move to the appropriate block
            //notebookFlow.ExecuteBlock("notebookActive");
        }else{
            NotebookActive = false;
            NotebookObj.SetActive(false);
            selectedClue = null;
        }
    }

    public void RefreshClues(){
        for (int i = 0; i < GatheredClues.Count; i++)
        {
            clueElements[i].GetComponent<ClueDisplay>().myClue = GatheredClues[i];
            clueElements[i].GetComponent<ClueDisplay>().InitClue();
        }
    }

    //used to click and select a clue
    public void SelectThis(GameObject target){
        if(selectedClue == null){
            selectedClue = target;
        }else{
            //deselect object
            if(currentClueHover){
                //add the baby clue to the gathered list
                if(!selectedClue.GetComponent<ClueDisplay>().myClue.connected){
                    GatheredClues.Add(selectedClue.GetComponent<ClueDisplay>().myClue.clueSpawn);
                    selectedClue.GetComponent<ClueDisplay>().myClue.connected = true;
                    selectedClue.GetComponent<ClueDisplay>().myClue.clueBuddy2.connected = true;
                    RefreshClues();
                }
                selectedClue.GetComponent<ClueDisplay>().ResetColor();
            }
            selectedClue = null;
        }

    }

    public void AddClue(ScriptableClue c){
        GatheredClues.Add(c);
        c.connected = false;
     
    }

}
