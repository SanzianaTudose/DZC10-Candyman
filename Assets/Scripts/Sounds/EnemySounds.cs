using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioClip patrolSound;
    [SerializeField] private AudioClip lockInSound;
    [SerializeField] private AudioClip chaseSound;
    [SerializeField] private AudioClip attackSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Patrol()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(patrolSound);
        }
    }
    public void LockIn()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(lockInSound);
        }
    }
    public void Chase()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(chaseSound);
        }
    }
    public void Attack()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(attackSound);
        }
    }
}
