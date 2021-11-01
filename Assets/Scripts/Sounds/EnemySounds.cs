using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioClip patrolSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Patrol()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(patrolSound);
        }
    }
}
