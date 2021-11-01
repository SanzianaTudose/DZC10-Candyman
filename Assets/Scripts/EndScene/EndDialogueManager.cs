using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndDialogueManager : MonoBehaviour
{
    int dialogueCount = 1;
    public Dialogue[] dialogue;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private AudioClip angryNPC;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (dialogueCount == 0)
                dialogueBox.SetActive(true);

            TriggerDialogue(dialogueCount);
            dialogueCount++;
        }
    }

    private void TriggerDialogue(int index) {
        GetComponentInParent<AudioSource>().Stop();
        GetComponentInParent<AudioSource>().PlayOneShot(angryNPC);

        if (index >= dialogue.Length) {
            OnEndGame();
            return;
        }

        nameText.text = dialogue[index].npcName;
        dialogueText.text = dialogue[index].sentence;
    }

    private void OnEndGame() {
        GetComponentInParent<AudioSource>().Stop();
        sceneChanger.FadeToScene("EndMenu");
    }
}
