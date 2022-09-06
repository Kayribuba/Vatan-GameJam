using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public event System.EventHandler<bool> DialogueStartedEvent;
    public static DialogueManager OnlyDialogueManager { get; private set; }

    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] float nextInputWaitTime = .2f;

    Queue<string> DialogueQueue = new Queue<string>();

    bool inDialogue;
    float cooldown = float.MaxValue;

    void Awake()
    {
        if(textMesh == null)
        {
            Debug.Log($"There is no textMesh attached to {name}. Destroying {name}");
        }

        if (OnlyDialogueManager == null)
            OnlyDialogueManager = this;
        else
            Destroy(this);
    }
    void Update()
    {
        if(inDialogue)
        {
            if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && cooldown <= Time.time)
            {
                if (DialogueQueue.Count > 0)
                {
                    textMesh.text = DialogueQueue.Dequeue();
                    cooldown = Time.time + nextInputWaitTime;
                }
                else
                    EndDialogue();
            }
        }
    }

    public void StartDialogue(EmployeeScript employeeToTalk)
    {
        inDialogue = true;
        DialogueStartedEvent?.Invoke(this, inDialogue);

        string[] newSentences = employeeToTalk.GetSentences();

        DialogueQueue.Clear();
        foreach (string s in newSentences)
            DialogueQueue.Enqueue(s);

        textMesh.text = DialogueQueue.Dequeue();
        cooldown = Time.time + nextInputWaitTime;

        textMesh.transform.parent.GetComponent<Animator>()?.SetBool("open", true);
    }
    public void EndDialogue()
    {
        inDialogue = false;
        DialogueStartedEvent?.Invoke(this, inDialogue);
        textMesh.transform.parent.GetComponent<Animator>()?.SetBool("open", false);
    }
    public void AddSentencesToDialogueQueue(string sentence) => DialogueQueue.Enqueue(sentence);
}
