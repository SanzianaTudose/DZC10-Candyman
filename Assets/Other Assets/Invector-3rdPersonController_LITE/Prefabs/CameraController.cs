using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject player;
    Vector3 offset;
    //Extra
    private Camera mainCam;
    public float hitBuffer = 0.5f;
    float originalCamDis;
    Vector3 originalCamPos;
    Vector3 p1;
    Vector3 p2;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        //for switching between indoors and outdoors
        mainCam = Camera.main;
        originalCamDis = Vector3.Distance(player.transform.position, mainCam.transform.position);
        originalCamPos = mainCam.transform.localPosition;
        p1 = player.transform.position;
        p2 = originalCamPos;
    }

    private void Update()
    {
        Debug.DrawLine(p1, p2);
        CheckForCollision();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = offset + player.transform.position;
    }

    private void CheckForCollision()
    {
        p1 = player.transform.position;
        p2 = transform.TransformPoint(originalCamPos);
        RaycastHit hit = new RaycastHit();
        if(Physics.Linecast(p1, p2, out hit))
        {
            Vector3 newCamPos = transform.InverseTransformPoint(hit.point);
            newCamPos = new Vector3(newCamPos.x, newCamPos.y - hitBuffer, newCamPos.z + hitBuffer);
            mainCam.transform.localPosition = newCamPos;
        }
        else
        {
            mainCam.transform.localPosition = originalCamPos;
        }
    }
}
