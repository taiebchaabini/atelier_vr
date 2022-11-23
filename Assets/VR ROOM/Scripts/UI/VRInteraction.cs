     using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using OculusSampleFramework;

public class VRInteraction : MonoBehaviour
{
    private bool doorAccess;
    private GameObject DistanceGrabHandRight;
    private GameObject item;
    private int interactions;
    private AudioSource escape;

    public void Start()
    {
        doorAccess = false;
        DistanceGrabHandRight = GameObject.Find("DistanceGrabHandRight");
        interactions = 0;
        escape = GameObject.Find("Escape").GetComponent<AudioSource>();
    }
    // Script 
    public void Interact()
    {
        doorAccess = GameObject.Find("ConsoleKey").gameObject.GetComponent<Console>().accessGranted;
        if (doorAccess && gameObject.name == "glass_panel_1_door")
        {
            transform.parent.GetComponent<Animator>().SetBool("character_nearby", true);
            transform.parent.GetComponent<NavMeshObstacle>().enabled = false;
        }
        else if (gameObject.name == "Projector")
        {
            if (interactions >= 4)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(GameObject.Find("escape_panel"));
                escape.Play();
            }
        }
        else if (doorAccess && transform.parent.parent.parent.name == "ChessBoard")
        {
            item = GameObject.Find(gameObject.name + "Key");
            if (item != null && item.GetComponent<DistanceGrabbable>().isGrabbed)
            {
                GameObject.Find("Projector").GetComponent<VRInteraction>().interactions += 1;
                gameObject.GetComponent<Renderer>().material = item.GetComponent<Renderer>().material;
                Destroy(item);
                item = null;
                // Must add a playsound for chess dropped
            } else{
               // Must add an Error sound for chess dropping;
            }
        }
    
    }
}
