using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(music);
    }
}
