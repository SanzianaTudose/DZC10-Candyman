using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private Animator animator;
    private string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("SceneChanger: Animator component not found.");
    }

    public void FadeToScene(string sceneName) {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
        
    } 

    private void OnFadeComplete() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
