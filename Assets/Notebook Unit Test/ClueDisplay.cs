using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;




public class ClueDisplay : MonoBehaviour {

    public ScriptableClue myClue;

    public TMP_Text myText;
    public Image myImage;

    public Color32 hovercolor;
    public Color32 defaultColor;

	// Use this for initialization
	void Awake () {

        //detect attached component to object and assign to reference
        if(this.GetComponent<TMP_Text>() != null){
            Debug.Log("should detect text");
            myText = this.GetComponent<TMP_Text>();
        }

        if(this.GetComponent<Image>() != null){
            myImage = this.GetComponent<Image>();
        }

	}
	
    public void InitClue(){

        if(myText != null){
            myText.text = myClue.clueText;
        }

        if(myImage != null){
            Debug.Log("still gotta make images");
        }
    }

    public void HoverHighlight(){
        if(myText != null){
            Debug.Log("highlight color");
            myText.color = hovercolor;
        }
    }

    public void ResetColor(){
        if(myText != null){
            Debug.Log("reset color");
            myText.color = defaultColor;
        }
    }
}
