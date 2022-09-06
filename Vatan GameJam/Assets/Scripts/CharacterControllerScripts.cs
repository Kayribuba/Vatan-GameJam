using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScripts : MonoBehaviour
{
    [SerializeField] float Speed = 10.0f;

    CharacterController cc;
    float gravityScale;
    bool InDialogue;

    void Start()
    {
        cc = GetComponent<CharacterController>();

        if (DialogueManager.OnlyDialogueManager != null)
            DialogueManager.OnlyDialogueManager.DialogueStartedEvent += CharacterControllerScripts_DialogueStartedEvent;
    }

    private void CharacterControllerScripts_DialogueStartedEvent(object sender, bool e)
    {
        InDialogue = e;
    }

    void Update()
    {

        if (!InDialogue)
        {
            if (cc.isGrounded)
                gravityScale = -.5f;
            else
                gravityScale = -9.81f;

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveVector = transform.forward * moveZ * Speed + transform.right * moveX * Speed;
            moveVector *= Time.deltaTime;
            moveVector.y = gravityScale;

            cc.Move(moveVector); 
        }
    }
}
