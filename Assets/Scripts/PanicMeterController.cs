using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanicMeterController : MonoBehaviour
{
    public Slider panicMeter;
    private float startValue = 0.0f;
    public Camera mainCamera;
    public float lowFov;
    public float defaultFov;

    // Start is called before the first frame update
    void Awake()
    {
        


    }

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
            mainCamera.fieldOfView = lowFov;
        } else
        {
            mainCamera.fieldOfView = defaultFov;
        }
    }


    private void ResetScene()
    {
        if(panicMeter.value == 1)
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
            
        }
    }

}
