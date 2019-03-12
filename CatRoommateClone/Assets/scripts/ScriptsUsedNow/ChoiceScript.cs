using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    public GameObject QuestionText;
    public GameObject Choice01;
    public GameObject Choice02;
    public int ChoiceMade;

    public void ChoiceOption1()
    {
        QuestionText.GetComponent<TextMeshProUGUI>().text = "Are you a night owl or an early riser?";
        ChoiceMade = 1;

    }
    
    public void ChoiceOption2()
    {
        QuestionText.GetComponent<TextMeshProUGUI>().text = "Are you a night owl or an early riser?";
        ChoiceMade = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (ChoiceMade >= 1)
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
        }
    }
}
