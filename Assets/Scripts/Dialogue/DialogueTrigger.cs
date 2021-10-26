using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;
    protected DialogueManager dialogueManager;

    private void Start() {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager == null)
            Debug.LogWarning("DialogueTrigger: DialogueManager object was not found.");
    }

    public virtual void TriggerDialogue(int index) {
        if (index > dialogue.Length)
            Debug.LogWarning("DialogueTrigger: index too big");

       dialogueManager.StartDialogue(dialogue[index]);
    }

    public void EndDialogue() {
        dialogueManager.EndDialogue();
    }
    public void TriggerFinalDialogue(int index) {
        if (index > dialogue.Length)
            Debug.LogWarning("DialogueTrigger: index too big");

        dialogueManager.FinalDialogue(dialogue[index]);
    }

}
