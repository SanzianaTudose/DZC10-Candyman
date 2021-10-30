using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour {
    [SerializeField] private GameObject compassObject;
    private List<Transform> targetObjects;
    [SerializeField] private GameObject objectIndicatorPrefab;
    [SerializeField] private GameObject objectIndicatorNPCPrefab;
    private Transform player;

    private Transform indicatorsContainer;
    private List<Transform> indicators;

    private Quaternion dirOffset = Quaternion.Euler(0, 0, -90);

    void Start() {
        player = PlayerManager.instance.player.transform;
        if (player == null)
            Debug.LogError("CompassController: Player instance not found.");

        indicatorsContainer = compassObject.transform.GetChild(0);
        if (player == null)
            Debug.LogError("CompassController: Indicators child not found.");

        targetObjects = new List<Transform>();
        indicators = new List<Transform>();
    }

    void LateUpdate() {
        SetIndicatorsDirection();
    }

    public void OnQuestActivate(List<Transform> questObjects) {
        foreach (Transform questObject in questObjects)
            targetObjects.Add(questObject);

        InstantiateIndicators(questObjects);
    }

    private void InstantiateIndicators(List<Transform> questObjects) {
        foreach (Transform target in questObjects) {
            GameObject prefabToUse;
            if (target.name == "QuestNPC")
                prefabToUse = objectIndicatorNPCPrefab;
            else
                prefabToUse = objectIndicatorPrefab;

            GameObject newIndicator = Instantiate(prefabToUse, prefabToUse.transform.position, prefabToUse.transform.rotation);
            newIndicator.transform.SetParent(indicatorsContainer, false);

            indicators.Add(newIndicator.transform);
        }
    }

    private void SetIndicatorsDirection() {
        for (int i = 0; i < targetObjects.Count; i++) {
            if (!targetObjects[i].gameObject.activeSelf) {
                indicators[i].gameObject.SetActive(false);
                continue;
            }

            Vector3 dir = player.position - targetObjects[i].position;

            Quaternion objectDir = Quaternion.LookRotation(dir);
            objectDir.z = -objectDir.y;
            objectDir.x = objectDir.y = 0;

            indicators[i].localRotation = objectDir * dirOffset;
        }
     }
}
