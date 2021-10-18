using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPrompt : MonoBehaviour
{
    public GameObject interactTxt;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactTxt.gameObject.SetActive(true);
            playerInteracts();
        }
    }
        
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactTxt.gameObject.SetActive(false);
        }
    }

    private void playerInteracts()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.transform.parent.GetComponent<GeneralQuest>() != null)
                this.transform.parent.GetComponent<GeneralQuest>().ActivateQuest();
        }
    }
}
