using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        // when items gets collected
        if (collider.gameObject.tag == "Player")
        {
            // add to counter of collected items and disable item
            transform.parent.transform.parent.GetComponent<GeneralQuest>().collectedItems += 1;
            transform.gameObject.SetActive(false);
        }
    }
}
