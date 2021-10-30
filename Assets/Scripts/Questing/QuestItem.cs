using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    private GeneralQuest parentQuest;

    private void Start() {
        parentQuest = transform.parent.transform.parent.GetComponent<GeneralQuest>();

        if (parentQuest == null)
            Debug.LogError("QuestItem: GeneralQuest component not found");
    }

    private void OnTriggerEnter(Collider collider)
    {
        // when items gets collected
        if (collider.gameObject.tag == "Player")
        {
            // add to counter of collected items and disable item
            transform.gameObject.SetActive(false);
            
            parentQuest.collectedItems += 1;
            parentQuest.UpdateUI();
        }
    }
}
