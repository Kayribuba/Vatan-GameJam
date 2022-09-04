using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToEmployee : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] Camera kamera;
    [SerializeField] LayerMask LayersToSee;

    [Header("Variable")]
    [SerializeField] float reach = 5f;

    [Header("Option")]
    [SerializeField] bool showRaycast;

    Ray ray;
    bool isSeeingLayers;

    void Start()
    {
        if (kamera == null && gameObject.GetComponent<Camera>() != null)
            kamera = gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        RaycastHit hitInfo;
        ray = new Ray(kamera.transform.position, kamera.transform.forward);
        Physics.Raycast(ray, out hitInfo, reach, LayersToSee);//---Kameradan Ray Cast'lendi---

        isSeeingLayers = hitInfo.collider != null;

        if (isSeeingLayers)//---adam raycast'e yakalandý---
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                Debug.Log("sa beybi lets go parti");
                //Diyalog çalýþtýr
            }
        }
    }
    void OnDrawGizmos()
    {
        if (showRaycast)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(ray.GetPoint(reach), new Vector3(.1f, .1f, .1f));
            Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * reach);
        }
    }
}
