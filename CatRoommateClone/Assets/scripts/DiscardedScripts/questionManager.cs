using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questionManager : MonoBehaviour
{
    public string catQ;
    public bool isGood;

    List<string> _questions = new List<string>() {"This is the first question"};
    
    


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = _questions[0];


        // Update is called once per frame
        void Update()
        {

        }
    }
}

