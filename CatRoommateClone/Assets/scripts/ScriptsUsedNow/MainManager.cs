using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine.Serialization;

public class MainManager : MonoBehaviour
{
    [FormerlySerializedAs("questions")] public ChoiceScript[] Questions;

    public Text SplodeText;

    public Text Question;
    public Text Choice1;
    public Text Choice2;
    

    private int _questionIndex = 0;
    private int _choiceSelected = 1;
    private int _totalScore = 0;

    private bool _gameEnd = false;

    public float Timer;

    public float Explode;
 
    private static List<questionManager> _unansweredQuestions;

    private questionManager _currentQuestion; 

    void Start()
    {
        Explode = Time.time + Timer;
        
        
        Question.text = Questions[_questionIndex].QuestionText;
        Choice1.text = Questions[_questionIndex].Choice01;
        Choice2.text = Questions[_questionIndex].Choice02;
        
        Choice1.color = Color.black;
    }

    void Update()
    {
        int _time = (int) (Explode - Time.time);
        if (_time <= 0)
        {
            _time = 0;
        }
        SplodeText.text = ":0" + _time;
        if (Explode < Time.time && _gameEnd == false)
        {
            Question.text = "We exploded! And worse: you lost!";
            Choice1.text = "";
            Choice2.text = "";
            _gameEnd = true;
        }
        print(_totalScore);
        if ( Input.GetKeyDown(KeyCode.RightArrow) && _choiceSelected == 1)
        {
            _choiceSelected = 2;
            Choice1.color = Color.white;
            Choice2.color = Color.black;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && _choiceSelected == 2)
        {
            _choiceSelected = 1;
            Choice1.color = Color.black;
            Choice2.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Explode = Time.time + Timer;

            if (_choiceSelected == 1)
            {
                _totalScore = _totalScore + 1;
            }
            else
            {
                _totalScore = _totalScore - 1;
            }

            _questionIndex = _questionIndex + 1;
            if (_questionIndex < Questions.Length)
            {
                Question.text = Questions[_questionIndex].QuestionText;
                Choice1.text = Questions[_questionIndex].Choice01;
                Choice2.text = Questions[_questionIndex].Choice02;
            }
            else
            {
                _gameEnd = true;
                if (_totalScore > 0)
                {
                    Question.text = "Let's be roommates!";
                    Choice1.text = "";
                    Choice2.text = "";
                }
                else
                {
                    Question.text = "We exploded! And even worse: you lost!";
                    Choice1.text = "";
                    Choice2.text = "";
                }

            }
            
        }
        
    }
}
