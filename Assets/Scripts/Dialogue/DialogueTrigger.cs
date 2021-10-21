using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager dialogueManager;

    private void Start() {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager == null)
            Debug.LogWarning("DialogueTrigger: DialogueManager object was not found.");
    }

    public void TriggerDialogue() {
        dialogueManager.StartDialogue(dialogue);
    }

    public void EndDialogue() {
        dialogueManager.EndDialogue();
    }
}
