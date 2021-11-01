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
    private AudioSource[] allAudioSources;
    [SerializeField] private AudioClip starWars;



    private void Start() {
        videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();
        if (videoPlayer == null)
            Debug.LogError("StartMenu: VideoPlayer component not found on VideoPlayer GameObject.");
        sceneChanger = sceneChangerObject.GetComponent<SceneChanger>();
        if (sceneChanger == null)
            Debug.LogError("StartMenu: SceneChanger component not found on sceneChangerObject");
    }

    public void OnClickPlay() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
        GetComponent<AudioSource>().PlayOneShot(starWars);

        imageObject.SetActive(true);
        videoPlayer.Play();

        StartCoroutine(LoadSceneAfterDelay(25f));
    }

    IEnumerator LoadSceneAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        sceneChanger.FadeToScene("SchoolScene");
    }
}
