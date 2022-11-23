using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private AudioSource error;
    private AudioSource success;
    // Start is called before the first frame update
    void Start()
    {
        error = GameObject.Find("AccessGranted").GetComponent<AudioSource>();
        success = GameObject.Find("AccessRefused").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Error()
    {
        error.Play();
    }

    public void Success()
    {
        success.Play();
    }
}
