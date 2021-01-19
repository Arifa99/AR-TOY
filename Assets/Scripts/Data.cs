using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
     
    Dictionary<string,string> questions = new Dictionary<string, string>();
    public Text questionText;

    void Start()
    {
        questions.Add( "What is the capital of India?", "25");
        questions.Add("Which is the largest state in India in terms of area?", "8");
        questions.Add("Which Indian state is popularly known as 'God\'s Own Country'?", "8");
        questions.Add("Which Indian state has the highest population?", "4");
        questions.Add("Which Indian state is surrounded by one state and three countries?", "7");
        questions.Add("Which Indian state is with the longest coastline?", "23");
        questions.Add("Which Indian state is called 'The Land of Legends'?", "23");
        questions.Add("Which Indian state is known as Golden Harvests for the great farmers?", "9");
        questions.Add("This state is known as the Heart of India because of it central location on India’s map!", "17");
        questions.Add("Which Indian state is the largest producer of banana, turmeric and tapioca in India?", "6");
        questions.Add("Which Indian state is also known as the Land of Coconut trees?", "18");
        questions.Add("Which Indian state is known for its Assamese golden silk called muga?", "29");
        questions.Add("Which Indian state is also known as ‘The Land of the Highlanders’?", "13");


    }

    public KeyValuePair<string,string> getQuestion(){
        int index = Random.Range(0, 13);
        

        KeyValuePair<string, string> pair = questions.ElementAt(index);
        Debug.Log(pair.Value);
        return pair;
    }

    public void ChangeQuestionText(string  text){
            questionText.text = text;
    }

    public bool isQuestionEmpty(){
        if(questionText.text == "")
        return true;
        return false;
    }


}
