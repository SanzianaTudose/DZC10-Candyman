using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleManager : MonoBehaviour
{
    [SerializeField] private GameObject castleDoor;

    public void openCastleDoor() {
        Animator anim = castleDoor.GetComponent<Animator>();
        if (anim == null)
            Debug.LogError("CastleManager: castle door Animator not found.");

        anim.Play("CastleDoor_Open");
    }
}