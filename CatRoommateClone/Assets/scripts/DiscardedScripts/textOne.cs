using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class textOne : MonoBehaviour
{
    private List<string> _firstchoice = new List<string>() {"First choice"};    
  
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = _firstchoice[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
