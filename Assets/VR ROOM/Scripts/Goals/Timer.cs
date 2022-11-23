using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    private float defaultTime;
    private float timer;
    private string remainingTime;
    private AudioSource halfTime;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultTime = 60 * 25;
        timer = defaultTime;
        halfTime = GameObject.Find("HalfTime").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 1)
        {
            timer -= Time.deltaTime;
            remainingTime = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60));
            this.GetComponent<TMP_Text>().text = remainingTime;
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        if (timer <= defaultTime / 2)
        {
            this.GetComponent<TMP_Text>().color = new Color(0.9333333f, 0.454902f, 0.145098f);
            halfTime.Play();
        }
        else if (timer <= defaultTime / 3)
        {
            this.GetComponent<TMP_Text>().color = Color.red;
            halfTime.Play();
        }

    
    }
}
