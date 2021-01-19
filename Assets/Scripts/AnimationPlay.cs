using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimationPlay : MonoBehaviour
{
    public Material corr_material;
    public Material wrong_material;
    public GameManager manager;
    [SerializeField] private Data data;
    [SerializeField] private Text Answerstatus;



    // private fields
    private Animator anim;
    private GameObject state1;
    private GameObject child_state;
    private Material orig_material;
    private string answer;

    public void getAnswer(string ans) {
        answer = ans;
    }

    /////////////////////////////////////////////////////////////////
    public void GetInput(String ans){
        Debug.Log("input " + ans);
        int input = Int16.Parse(ans);
        if(input > 0 && input < 30){
            state1 =  GameObject.Find(ans);
            GameObject cube = state1.transform.GetChild(0).gameObject;
            child_state = cube.transform.GetChild(0).gameObject;
            orig_material = child_state.GetComponent<Renderer>().material;
            anim = state1.GetComponent<Animator> ();
            if(data.isQuestionEmpty()){
                    generateNewQuestion(); // incase the question field is empty
            }
            // Debug.Log(ans == answer);
            if(ans == answer){
            ChangeStatus(true);
            StartCoroutine (AnimateStateForCorrect ());
            }
            else{
            ChangeStatus(false);
            StartCoroutine (AnimateStateForWrong ());
            }
        }
    }

    ////////////////////////////////////////////////////////
    private void ChangeStatus(bool correct){
        if(correct)
        Answerstatus.text = "CORRECT";
        else
        Answerstatus.text = "TRY AGAIN";
    }
  
    ///////////////////////////////////////////////////////////
    void generateNewQuestion(){
        Answerstatus.text = "";
        KeyValuePair<string, string> pair = data.getQuestion();
        data.ChangeQuestionText(pair.Key);
        answer = pair.Value;
    }

    /////////////////////////////////////////////////////////////

      IEnumerator AnimateStateForCorrect () {
        anim.SetBool("move", true);
        Color origColor = orig_material.color;
        orig_material.color = Color.green;
        yield return new WaitForSeconds (2.5f);
        anim.SetBool("move", false);
        orig_material.color = origColor;
        generateNewQuestion();
    }

    IEnumerator AnimateStateForWrong () {
        anim.SetBool("move", true);
        Color origColor = orig_material.color;
        orig_material.color = Color.red;
        yield return new WaitForSeconds (1.5f);
        anim.SetBool("move", false);
        orig_material.color = origColor;
    }
}
