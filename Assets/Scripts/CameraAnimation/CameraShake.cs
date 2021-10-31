using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Shake Variables")]
    [SerializeField] float duration = 3f;
    [SerializeField] float startMagnitude = 0.4f;
    [SerializeField] float stepMagnitude = 0.1f;

    public bool isShaking = false;

    public void startShake() {
        isShaking = true;
        StartCoroutine(Shake());
    }

    public IEnumerator Shake() {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f, magnitude = startMagnitude;
        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector3(x, y, z);

            elapsed += Time.deltaTime;
            magnitude += stepMagnitude;

            yield return null;
        }

        isShaking = false;
        transform.localPosition = originalPos;
    }
}
