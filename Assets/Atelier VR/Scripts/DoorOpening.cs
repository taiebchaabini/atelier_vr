using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public AudioClip[] actions;
    public AudioSource audioComp;
    private void OnTriggerEnter(Collider other) {
        GetComponent<Animator>().SetBool("character_nearby", true);
        audioComp.Stop();
        audioComp.clip = actions[1];
        audioComp.Play();
    }

    private void OnTriggerExit(Collider other) {
        GetComponent<Animator>().SetBool("character_nearby", false);
        audioComp.Stop();
        audioComp.clip = actions[0];
        audioComp.Play();
    }
}
