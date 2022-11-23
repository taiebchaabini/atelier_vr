using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Console : MonoBehaviour
{
    // Collects multiple gameobjects that contains the code
    public List<RandomWord> keys; 
    // Gets Console's typed code.
    public InputField codeInputField;
    // Gives access to the door
    public bool accessGranted;

    
    private TMP_Text inputCodeTMP;
    private string inputCode;
    // Code access
    public string code;

    public Animator console;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            code += keys[i].wordCode;
        }
        inputCodeTMP = codeInputField.transform.Find("Text").GetComponent<TMP_Text>();
        accessGranted = false;
        console = GameObject.Find("Console").GetComponent<Animator>();
    }

    // Reset the code on the console
    public void resetCode()
    {
        inputCodeTMP.text = "";
    }

    // Add number to the inputCodeField
    public void addNumber(string nb)
    {
        if (inputCodeTMP.text.Length != 4)
            inputCodeTMP.text += nb;
    }

    // Check if the code is correct
    // Opens the door or Shows up an error if the code is not correct
    public void checkCode()
    { 
        if (inputCodeTMP.text.Length > 0)
            inputCode = inputCodeTMP.text;
        else
            inputCode = "";

        if (inputCode == code)
        {
            // Unlock the door and make an animation
            accessGranted = true;
            console.SetTrigger("Success");
        }
        else
            // Make error massage animation
            console.SetTrigger("Error");
    }
}
