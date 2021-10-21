using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;

    public void StartDialogue(Dialogue dialogue) {
        nameText.text = dialogue.name;
        dialogueText.text = dialogue.sentence;
        
        dialogueBox.SetActive(true);
    }

    public void EndDialogue() {
        dialogueBox.SetActive(false);
    }

}
