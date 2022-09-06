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
    [SerializeField] float nextInputWaitTime = .5f;

    [Header("Option")]
    [SerializeField] bool showRaycast;

    DialogueManager DM;
    Ray ray;
    float cooldown;
    bool isSeeingLayers;
    bool isPlayerInDialogue;

    void Start()
    {
        DM = DialogueManager.OnlyDialogueManager;
        if (DM != null)
            DM.DialogueStartedEvent += OnlyDM_DialogueStartedEvent1;

        if (kamera == null && gameObject.GetComponent<Camera>() != null)
            kamera = gameObject.GetComponent<Camera>();
    }

    void OnlyDM_DialogueStartedEvent1(object sender, bool e)
    {
        isPlayerInDialogue = e;
        cooldown = Time.time + nextInputWaitTime;
    }

    void Update()
    {
        RaycastHit hitInfo;
        ray = new Ray(kamera.transform.position, kamera.transform.forward);
        Physics.Raycast(ray, out hitInfo, reach, LayersToSee);//---Kameradan Ray Cast'lendi---

        isSeeingLayers = hitInfo.collider != null;

        if (isSeeingLayers && hitInfo.collider.GetComponent<EmployeeScript>() != null)//---adam raycast'e yakalandý---
        {
            EmployeeScript ESInRaycast = hitInfo.collider.gameObject.GetComponent<EmployeeScript>();

            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                if(!isPlayerInDialogue && cooldown <= Time.time)
                {
                    DM.StartDialogue(ESInRaycast);
                }
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
