using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrababbleAnswer : MonoBehaviour
{
	public TMP_Text answer;

    private void OnTriggerEnter(Collider other)
    {   
        // Layers Console
        if (other.gameObject.layer == 7)
        {
            var consoleScript = other.GetComponent<ConsoleScript>();
            var audio = consoleScript.GetComponent<AudioSource>();

            if (consoleScript.Answer == answer.text)
            {
                consoleScript.QuestionText.text = "Door open!";
                consoleScript.door.transform.gameObject.SetActive(false);
                other.gameObject.layer = 0;
                audio.clip = consoleScript.actions[1];
            }
            else
            {
                StartCoroutine(showErrorMessages(consoleScript, audio));
            }

            audio.Stop();
            audio.Play();
        }
            // add to event listener that there is a wrong error

    }

    IEnumerator  showErrorMessages(ConsoleScript consoleScript, AudioSource audio)
    {
        var tmp = consoleScript.QuestionText.text;
        consoleScript.QuestionText.text = "Wrong answer!";
        
        audio.clip = consoleScript.actions[0];
        yield return new WaitForSeconds(3);
        consoleScript.QuestionText.text = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
