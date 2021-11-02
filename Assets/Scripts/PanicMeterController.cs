using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanicMeterController : MonoBehaviour
{
    [SerializeField] private GameObject healthLowImage;
    [SerializeField] private AudioClip hurtAudio;
    public Slider panicMeter;
    private float startValue = 0.0f;
    public Camera mainCamera;
    public float lowFov;
    public float defaultFov;

    private void Start()
    {
        //panic meter  start value
        panicMeter.value = startValue;
    }


    private void Update()
    {
        CameraSettings();
        ResetScene();
        
    }

    //change camera fov once panicmeter is really high
    private void CameraSettings()
    {
        if(panicMeter.value > 0.8f)
        {
            healthLowImage.SetActive(true);
            //mainCamera.fieldOfView = lowFov /1.75f;
            mainCamera.fieldOfView = defaultFov / 1.75f;
            GetComponent<AudioSource>().PlayOneShot(hurtAudio);

        } else
        {
            GetComponent<AudioSource>().Stop();
            healthLowImage.SetActive(false);
            mainCamera.fieldOfView = defaultFov /1.75f;
        }
    }


    private void ResetScene()
    {
        if (panicMeter.value == 1)
        {
            SceneManager.LoadScene("SchoolScene");
            
        }
    }

}
