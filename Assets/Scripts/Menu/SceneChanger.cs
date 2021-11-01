using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator animator;
    private string sceneToLoad;

    [Header("Shake Transition Variables")]
    [SerializeField] private float duration = 3f;
    [SerializeField] private float startMagnitude = 0.4f;
    [SerializeField] private float stepMagnitude = 0.1f;

    [SerializeField] CameraShake cameraShake;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("SceneChanger: Animator component not found.");
    }

    public IEnumerator StartShakeTransition(string sceneName) {
        StartCoroutine(cameraShake.Shake(duration, startMagnitude, stepMagnitude));
        yield return new WaitForSeconds(duration - 3f);
        FadeToScene(sceneName);
    }

    public void FadeToScene(string sceneName) {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    } 

    private void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
