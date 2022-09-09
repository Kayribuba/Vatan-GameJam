using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] Camera kamera;
    [SerializeField] float reach = 6f;
    [SerializeField] float waitTime = 3f;
    [SerializeField] LayerMask LayersToSee;

    Ray ray;
    RaycastHit hitInfo;
    float targetTime = float.MaxValue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            ray = new Ray(kamera.transform.position, kamera.transform.forward);
            Physics.Raycast(ray, out hitInfo, reach, LayersToSee);//---Kameradan Ray Cast'lendi---

            if (hitInfo.collider != null)
                targetTime = Time.time + waitTime;
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0))
        {
            targetTime = float.MaxValue;
        }
        if(targetTime <= Time.time)
        {
            FindObjectOfType<TimerScript>().EndTime();
        }
    }
}
