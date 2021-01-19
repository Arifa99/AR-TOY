using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject Panel;
    public GameObject India;
    public Data data;
    public GameObject quiz;
    public GameObject button;
    private string ans;

    public AnimationPlay player;

    public string giveAns () {
        return ans;
    }

    public void OnButtonClick () {
        Panel.SetActive (!Panel.activeSelf);
    }

    private void Start () {
        if (data.isQuestionEmpty ()) {
            KeyValuePair<string, string> pair = data.getQuestion ();
            data.ChangeQuestionText (pair.Key);
            ans = pair.Value;
            player.getAnswer (ans);
        }
    }

    public void ActivateQuiz () {
        quiz.SetActive (true);
        button.SetActive (false);
        India.SetActive(true);
    }

    public void InactivateQuiz(){
        quiz.SetActive (false);
        button.SetActive (true);
        India.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void QuizScene() 
    { 
  
        SceneManager.LoadScene("Main Scene");
    }

    public void ARQuizScene()
    {

        SceneManager.LoadScene("ARQuiz");
    }


}