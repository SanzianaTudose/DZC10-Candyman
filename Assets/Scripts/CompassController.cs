using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassController : MonoBehaviour {
    Quaternion dirOffset = Quaternion.Euler(0, 0, -90);

    private Transform player;
    [SerializeField] private Transform targetObject;

    [SerializeField] private RectTransform objectIndicator;

    void Start() {
        player = PlayerManager.instance.player.transform;
    }

    void Update() {
        SetIndicatorDirection();
    }

    private void SetIndicatorDirection() {
        Vector3 dir = player.position - targetObject.position;

        Quaternion objectDir = Quaternion.LookRotation(dir);
        objectDir.z = -objectDir.y;
        objectDir.x = objectDir.y = 0;

        objectIndicator.localRotation = objectDir * dirOffset;
    }
}
