using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARManager : MonoBehaviour
{
    public void QuitMyApp()
    {
        Application.Quit();
    }

    public void QuizMyScene()
    {

        SceneManager.LoadScene("Main Scene");
    }

    public void ARQuizMyScene()
    {

        SceneManager.LoadScene("ARQuiz");
    }

}
