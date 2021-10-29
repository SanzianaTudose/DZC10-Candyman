using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject videoPlayerObject;
    [SerializeField] private GameObject imageObject;
    [SerializeField] private GameObject sceneChangerObject;
    private VideoPlayer videoPlayer;
    private SceneChanger sceneChanger;


    private void Start() {
        videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();
        if (videoPlayer == null)
            Debug.LogError("StartMenu: VideoPlayer component not found on VideoPlayer GameObject.");
        sceneChanger = sceneChangerObject.GetComponent<SceneChanger>();
        if (sceneChanger == null)
            Debug.LogError("StartMenu: SceneChanger component not found on sceneChangerObject");
    }

    public void OnClickPlay() {
        imageObject.SetActive(true);
        videoPlayer.Play();

        StartCoroutine(LoadSceneAfterDelay(25f));
    }

    IEnumerator LoadSceneAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        sceneChanger.FadeToScene("SchoolScene");
    }
}
