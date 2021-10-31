using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CandymanController : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private SceneChanger sceneChanger;
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

            dialogueTrigger.EndDialogue();
            playerInRange = false;
        }
    }

    public void OnCandyChosen(Button button) {
        dialogueTrigger.EndDialogue();
        playerChoseCandy = true;

        if (button.gameObject.tag == "Candy1")
        {
            Debug.Log("Speeed");
        }
        else if (button.gameObject.tag == "Candy2")
        {
            Debug.Log("More Vision");
        }
        else if (button.gameObject.tag == "Candy3") 
        { 
            Debug.Log("No power-up"); 
        }

        StartCoroutine(sceneChanger.StartShakeTransition("MainScene"));

            //SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
