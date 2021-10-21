using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    private GeneralQuest quest;
    private bool playerInRange = false;
    private bool questAlreadyTaken = false;

    private void Start()
    {
        quest = GetComponent<GeneralQuest>();
        if (quest == null)
            Debug.LogWarning("No quest component found!");
    }
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E) && !questAlreadyTaken)
        {
            questAlreadyTaken = true;
            interactText.gameObject.SetActive(false);
            quest.ActivateQuest();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !questAlreadyTaken)
        {
            interactText.gameObject.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(false);
            playerInRange = false;
        }
    }
}
