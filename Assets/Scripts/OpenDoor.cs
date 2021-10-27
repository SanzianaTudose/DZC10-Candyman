using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private bool animate = false;

    void Start() {
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.Log("OpenDoor: Animator component not found.");
    }

    private void Update() {
        if (animate == true) {
            anim.Play("CastleDoor_Open");
        }
    }
}