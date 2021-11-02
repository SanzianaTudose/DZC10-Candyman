using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CandymanController : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private float newSpeedRatio;
    [SerializeField] private float[] newLockInOfEnemies;
    [SerializeField] private AudioClip gibberishNPC;
    [SerializeField] private AudioClip gibberishNPC2;

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
            dialogueTrigger.TriggerDialogue(0);
            interactText.gameObject.SetActive(false);
            GetComponent<AudioSource>().PlayOneShot(gibberishNPC);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && !playerChoseCandy) {
            interactText.gameObject.SetActive(true);

            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            interactText.gameObject.SetActive(false);

            GetComponent<AudioSource>().Stop();
            dialogueTrigger.EndDialogue();
            playerInRange = false;
        }
    }

    public void OnCandyChosen(Button button) {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(gibberishNPC2);

        dialogueTrigger.EndDialogue();
        playerChoseCandy = true;
        PlayerController player = PlayerManager.instance.player.GetComponent<PlayerController>();

        if (button.gameObject.tag == "Candy1")
        {
            SetPlayerAttributes.Speed = newSpeedRatio * player.speed;
            SetPlayerAttributes.LockInMin = 0;
            SetPlayerAttributes.LockInMax = 0;
        }
        else if (button.gameObject.tag == "Candy2")
        {
            SetPlayerAttributes.Speed = 0;
            SetPlayerAttributes.LockInMin = newLockInOfEnemies[0];
            SetPlayerAttributes.LockInMax = newLockInOfEnemies[1];
        }
        else if (button.gameObject.tag == "Candy3") 
        { 
            Debug.Log("No power-up");
            SetPlayerAttributes.Speed = 0;
            SetPlayerAttributes.LockInMin = 0;
            SetPlayerAttributes.LockInMax = 0;
        }

        StartCoroutine(sceneChanger.StartShakeTransition("MainScene"));
    }
}
