using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GeneralQuest : MonoBehaviour
{
    public Transform[] QuestItems;
    [HideInInspector] public bool questIsActive;
    [HideInInspector] public int collectedItems;
    public bool questComplete;

    [SerializeField] private GameObject gameManager;

    // UI Variables
    [SerializeField] private GameObject questProgression;
    private TextMeshProUGUI questText;
    CompassManager compassManager;

    private void Start()
    {
        DeactivateQuest();
        collectedItems = 0;
        questIsActive = false;
        questComplete = false;

        questText = questProgression.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (questText == null)
            Debug.LogError("GeneralQuest: GeneralQuest component not found");

        compassManager = gameManager.GetComponent<CompassManager>();
        if (compassManager == null)
            Debug.LogError("GeneralQuest: CompassManager component not found on GameManager object");
    }

    public void ActivateQuest()
    {
        collectedItems = 0;
        questIsActive = true;

        // Activate objects 
        foreach (var item in QuestItems)
        {
            item.gameObject.SetActive(true);
        }

        // Update compass
        compassManager.OnQuestActivate(new List<Transform>(QuestItems));

        // Update UI
        questProgression.SetActive(true);
        UpdateUI();
    }

    public void DeactivateQuest()
    {
        questIsActive = false;

        // Activate objects 
        foreach (var item in QuestItems)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void UpdateUI() {
        if (collectedItems < QuestItems.Length) {
            questText.text = collectedItems + " out of " + QuestItems.Length + " items collected";

        } else {
            questText.text = "Quest complete! Go back to the King";
            compassManager.OnQuestActivate(new List<Transform> { transform });
            questComplete = true; // this shouldn't be checked in the UpdateUI() method but whatever
        }
    }
}
