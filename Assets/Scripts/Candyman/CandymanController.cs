using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandymanController : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    private DialogueTrigger dialogueTrigger;

    private bool playerInRange = false; // Don't display dialogue box when Player is not in range
    private bool playerChoseCandy = false; // Only show dialogue if Player has not chosen any candy

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        if (dialogueTrigger == null)
            Debug.LogWarning("CandymanController: DialogueTrigger component not found.");
    }

    private void Update() {
        if (!playerChoseCandy && playerInRange && Input.GetKeyDown(KeyCode.E)) {
            dialogueTrigger.TriggerDialogue();
            interactText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            interactText.gameObject.SetActive(true);

            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            interactText.gameObject.SetActive(false);

            dialogueTrigger.EndDialogue();
            playerInRange = false;
        }
    }

    public void OnCandyChosen(Button button) {
        dialogueTrigger.EndDialogue();
        playerChoseCandy = true;

        Debug.Log(button.name);
    }
}
