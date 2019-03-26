using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

public class MainManager : MonoBehaviour
{
    public ChoiceScript[] questions;

    public Text splodeText;

    public Text Question;
    public Text Choice1;
    public Text Choice2;
    

    private int questionIndex = 0;
    private int ChoiceSelected = 1;
    private int totalScore = 0;

    private bool GameEnd = false;

    public float Timer;

    public float Explode;
 
    //private static List<questionManager> _unansweredQuestions;

   // private questionManager currentQuestion; 

    void Start()
    {
        Explode = Time.time + Timer;
        
        
        Question.text = questions[questionIndex].QuestionText;
        Choice1.text = questions[questionIndex].Choice01;
        Choice2.text = questions[questionIndex].Choice02;
        
        Choice1.color = Color.gray;
    }

    void Update()
    {
        int _time = (int) (Explode - Time.time);
        if (_time <= 0)
        {
            _time = 0;
        }
        splodeText.text = ":0" + _time;
        if (Explode < Time.time && GameEnd == false)
        {
            Question.text = "We esploded";
            Choice1.text = "";
            Choice2.text = "";
            GameEnd = true;
        }
        print(totalScore);
        if ( Input.GetKeyDown(KeyCode.RightArrow) && ChoiceSelected == 1)
        {
            ChoiceSelected = 2;
            Choice1.color = Color.white;
            Choice2.color = Color.gray;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && ChoiceSelected == 2)
        {
            ChoiceSelected = 1;
            Choice1.color = Color.gray;
            Choice2.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Explode = Time.time + Timer;

            if (ChoiceSelected == 1)
            {
                totalScore = totalScore + 1;
            }
            else
            {
                totalScore = totalScore - 1;
            }

            questionIndex = questionIndex + 1;
            if (questionIndex < questions.Length)
            {
                Question.text = questions[questionIndex].QuestionText;
                Choice1.text = questions[questionIndex].Choice01;
                Choice2.text = questions[questionIndex].Choice02;
            }
            else
            {
                GameEnd = true;
                if (totalScore > 0)
                {
                    Question.text = "Let's be roommates!";
                    Choice1.text = "";
                    Choice2.text = "";
                }
                else
                {
                    Question.text = "I can't live with you...";
                    Choice1.text = "";
                    Choice2.text = "";
                }

            }
            
        }
        
    }
}
