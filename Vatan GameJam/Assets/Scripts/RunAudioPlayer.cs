using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RunAudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    AudioSource AuSo;
    bool ended;

    private void Awake()
    {
        AuSo = GetComponent<AudioSource>();
    }

    public void EndTime()
    {
        if (!ended)
        {
            AuSo.Stop();
            AuSo.clip = this.clip;
            AuSo.loop = false;
            AuSo.Play();
            ended = true;
        }
    }
}
