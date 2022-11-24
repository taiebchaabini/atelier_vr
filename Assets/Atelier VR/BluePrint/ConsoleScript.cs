using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    
    public BluePrintSO BPS;
    public TMPro.TMP_Text QuestionText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        QuestionText.text = BPS.Title;    
    }
}
