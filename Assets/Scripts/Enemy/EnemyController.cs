using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] private Transform pfFieldOfView;
    private FieldOfView fieldOfView;
    private EnemySM enemySM;

    private void Start() {
        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FieldOfView>();
        enemySM = GetComponent<EnemySM>();
    }

    private void Update() {
        UpdateFOV();
        enemySM.playerInRange = fieldOfView.playerInRange;
    }

    private void UpdateFOV() {
        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetStartingAngle(-transform.eulerAngles.y);
    }
}
