using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HostDialogue : MonoBehaviour //evet hardcode ama napim sýkýldým
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] float nextInputWaitTime = .2f;

    Queue<string> DialogueQueue = new Queue<string>();
    float cooldown = float.MaxValue;

    void Start()
    {
        DialogueQueue.Enqueue("And now ladies and gentlemen we are here with our last contestant.");
        DialogueQueue.Enqueue("Our dear contestant, are you ready?");
        DialogueQueue.Enqueue("(Press E or LMB to start the competition)");

        
    }
}
