using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour {
    [SerializeField] private List<Transform> targetObjects;
    [SerializeField] private GameObject objectIndicatorPrefab;
    private Transform player;

    private Transform indicatorsContainer;
    private List<Transform> indicators;

    private Quaternion dirOffset = Quaternion.Euler(0, 0, -90);

    void Start() {
        player = PlayerManager.instance.player.transform;
        if (player == null)
            Debug.LogError("CompassController: Player instance not found.");

        indicatorsContainer = transform.GetChild(0);
        if (player == null)
            Debug.LogError("CompassController: Indicators child not found.");

        InstantiateIndicators();
    }

    void Update() {
        SetIndicatorsDirection();
    }

    private void InstantiateIndicators() {
        indicators = new List<Transform>();

        foreach (Transform target in targetObjects) {
            GameObject newIndicator = Instantiate(objectIndicatorPrefab, objectIndicatorPrefab.transform.position, objectIndicatorPrefab.transform.rotation);
            newIndicator.transform.SetParent(indicatorsContainer, false);

            indicators.Add(newIndicator.transform);
        }
    }

    private void SetIndicatorsDirection() {
        for (int i = 0; i < targetObjects.Count; i++) { 
            Vector3 dir = player.position - targetObjects[i].position;

            Quaternion objectDir = Quaternion.LookRotation(dir);
            objectDir.z = -objectDir.y;
            objectDir.x = objectDir.y = 0;

            indicators[i].localRotation = objectDir * dirOffset;
        }
     }
}
