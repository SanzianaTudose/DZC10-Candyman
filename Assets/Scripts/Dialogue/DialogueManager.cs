using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject candyChoices;
    [SerializeField] private GameObject questChoices;
    [SerializeField] private GameObject finalChoices;
    [SerializeField] private GameObject compass;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;

    public void StartDialogue(Dialogue dialogue) {
        nameText.text = dialogue.npcName;
        dialogueText.text = dialogue.sentence;

        compass.SetActive(false);
        dialogueBox.SetActive(true);

        if (dialogue.npcName == "King of Belgium") {
            questChoices.SetActive(true);
        }
        if (dialogue.npcName == "Candyman") {
            candyChoices.SetActive(true);
        }
    }

    public void EndDialogue() {
        dialogueBox.SetActive(false);
        compass.SetActive(true);
        finalChoices.SetActive(false);
        candyChoices.SetActive(false);
        questChoices.SetActive(false);
    }

    public void FinalDialogue(Dialogue dialogue) {
        nameText.text = dialogue.npcName;
        dialogueText.text = dialogue.sentence;

        compass.SetActive(false);
        dialogueBox.SetActive(true);
        finalChoices.SetActive(true);
    }
}
