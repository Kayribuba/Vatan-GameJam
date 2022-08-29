using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerScripts : MonoBehaviour
{
    [SerializeField] float Speed = 10.0f;

    CharacterController cc;
    float gravityScale;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
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
