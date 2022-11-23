using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomWord : MonoBehaviour
{
    public TextAsset textFile;
    public int wordCode;

    private string[] words;

    public IDictionary<char, int> alphabet = new Dictionary<char, int>(){
        {'A', 1}, {'B', 2},{'C', 3}, {'D', 4}, {'E', 5}, {'F', 6},
        {'G', 1}, {'H', 2},{'I', 3}, {'J', 4}, {'K', 5}, {'L', 6},
        {'M', 1}, {'N', 2},{'O', 3}, {'P', 4}, {'Q', 5}, {'R', 6},
                {'S', 1}, {'T', 2},{'U', 3}, {'V', 4},
                {'W', 1}, {'X', 2},{'Y', 3}, {'Z', 4}
    };

    public string word;
    // Start is called before the first frame update
    void Start()
    {
        words = textFile.text.Split( ' ' );
        word = words[Random.Range(0, words.Length)].ToUpper();
        wordCode = alphabet[word[0]];
        transform.Find("Canvas").transform.Find("Text (TMP)").GetComponent<TMP_Text>().text = word;
    }
    

}
