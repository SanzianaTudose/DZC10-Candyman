using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private SceneChanger sceneChanger;
    private GeneralQuest quest;
    private bool playerInRange = false;
    private bool questAlreadyTaken = false;

    private DialogueTrigger dialogueTrigger;
    [SerializeField] private GameObject gameManager;

    private void Start()
    {
        quest = GetComponent<GeneralQuest>();
        if (quest == null)
            Debug.LogWarning("No quest component found!");

        dialogueTrigger = GetComponent<DialogueTrigger>();
        if (dialogueTrigger == null)
            Debug.LogError("PlayerInteraction: No DialogueTrigger component found!");
    }
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!questAlreadyTaken) {
                interactText.gameObject.SetActive(false);
                dialogueTrigger.TriggerDialogue(0);
            } else if (quest.questComplete) {
                interactText.gameObject.SetActive(false);
                dialogueTrigger.TriggerFinalDialogue(1);
            }
            
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (!questAlreadyTaken || quest.questComplete))
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

            dialogueTrigger.EndDialogue();
        }
    }

    public void OnQuestAccept() {
        questAlreadyTaken = true;
        quest.ActivateQuest();
        dialogueTrigger.EndDialogue();

        // Notify CastleManager to open castle door
        if (gameManager.GetComponent<CastleManager>() != null)
            gameManager.GetComponent<CastleManager>().openCastleDoor();
    }

    public void OnQuestReject() {
        dialogueTrigger.EndDialogue();
    }

    public void OnFinalDialogueEnd() {
        StartCoroutine(sceneChanger.StartShakeTransition("EndScene"));
    }
}
