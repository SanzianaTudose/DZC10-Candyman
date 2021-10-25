using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicMeterController : MonoBehaviour
{
    public Slider panicMeter;
    private float startValue = 0.0f;
    public Camera mainCamera;
    public float lowFov = 40.0f;
    public float defaultFov = 56.0f;

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
        
    }

    //change camera fov once panicmeter is really high
    private void CameraSettings()
    {
        if(panicMeter.value > 0.8f)
        {
            mainCamera.fieldOfView = lowFov;
        } else
        {
            mainCamera.fieldOfView = 56.0f;
        }
    }

}
