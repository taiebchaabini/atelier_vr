using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CrosshairUI : MonoBehaviour
{   
    // Laser default Length
    public float laserLength = 3.0f;
    // Crosshair Gameobject
    public GameObject crosshair;
    // Laser color
    public Material normal;
    // Laser hover color
    public Material hover;
    
    private Vector3 endPoint;
    private LineRenderer lineRenderer = null;


    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLength();
    }

    private void Update()
    {
        CheckTeleportLaser();
        UpdateLength();
        //UpdatePosition();
    }

    // Disables the Laser when teleport laser shows up.
    private void CheckTeleportLaser()
    {
        if (OVRInput.Get(OVRInput.Touch.Two))
            lineRenderer.enabled = false;
        else
            lineRenderer.enabled = true;
    }

    // Update cursor length
    private void UpdateLength()
    {
        endPoint = GetEnd();

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPoint);
    }

    // Update the position of the crosshair according to laser position.
    private void UpdatePosition()
    {
        crosshair.transform.position = endPoint;
    }

    // Updates end position of the laser
    private Vector3 GetEnd()
    {
        RaycastHit hit = RayCast();
        Vector3 endPos = DefaultEnd(laserLength);

        if (hit.collider)
        {
            if (hit.collider.gameObject.layer == 10)
            {
                lineRenderer.material = hover;
                if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                    hit.collider.gameObject.GetComponent<VRInteraction>().Interact();
            }
            else
                lineRenderer.material = normal;
    
            endPos = hit.point;
        }

        return endPos;
    }

    // Raycast used to detect collision
    private RaycastHit RayCast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, laserLength);

        return hit;
    }


    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }

}
