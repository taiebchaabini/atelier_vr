using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrababbleAnswer : MonoBehaviour
{
    public string answer;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {   
        // Layers Console
        if (other.gameObject.layer == 7)
        {
            var consoleScript = other.GetComponent<ConsoleScript>();
            if (consoleScript.Answer == answer)
            {
                consoleScript.QuestionText.text = "Door open!";
            }
            else
            {
                consoleScript.QuestionText.text = "Wrong answer!";
            }
        }
            // add to event listener that there is a wrong error

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
