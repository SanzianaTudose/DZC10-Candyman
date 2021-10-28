using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBeginningCutscene : MonoBehaviour
{
    public GameObject cutSceneCam;
    public int durationBegCutScene;
    public GameObject playerFollowCam;
    public GameObject player;
    public GameObject playerCopy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBeginningCutscene());
    }

    IEnumerator StartBeginningCutscene() {
        playerCopy.SetActive(true);
        player.SetActive(false);
        yield return new WaitForSeconds(durationBegCutScene);
        playerFollowCam.SetActive(true);
        cutSceneCam.SetActive(false);
        player.SetActive(true);
        playerCopy.SetActive(false);
        Destroy(this);
    }
}
