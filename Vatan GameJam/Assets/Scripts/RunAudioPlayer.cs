using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RunAudioPlayer : MonoBehaviour
{
    AudioSource AuSo;

    private void Awake()
    {
        AuSo = GetComponent<AudioSource>();
    }

    public void EndTime()
    {

    }
}
