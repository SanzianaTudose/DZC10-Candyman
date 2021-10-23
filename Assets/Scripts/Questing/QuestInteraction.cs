using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInteraction : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
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

            // Notify CastleManager to open castle door
            if (gameManager.GetComponent<CastleManager>() != null)
                gameManager.GetComponent<CastleManager>().openCastleDoor();

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
