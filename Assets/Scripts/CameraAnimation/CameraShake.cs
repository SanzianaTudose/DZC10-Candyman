using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public IEnumerator Shake(float duration, float startMagnitude, float stepMagnitude) {
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

        transform.localPosition = originalPos;
    }
}
