using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrababbleAnswer : MonoBehaviour
{
	public TMP_Text answer;

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
            if (consoleScript.Answer == answer.text)
            {
                consoleScript.QuestionText.text = "Door open!";
                consoleScript.door.transform.gameObject.SetActive(false);
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
