using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offset;
	//Extra
	private Camera mainCam;
	public float hitBuffer = 0.5f;
	float originalCamDis;
	Vector3 originalCamPos;
	Vector3 p1;
	Vector3 p2;

    private void Start()
    {
		//for switching between indoors and outdoors
		mainCam = Camera.main;
		originalCamDis = Vector3.Distance(target.transform.position, mainCam.transform.position);
		originalCamPos = mainCam.transform.localPosition;
		p1 = target.transform.position;
		p2 = originalCamPos;
	}

    private void Update()
    {
		//CheckForCollision();
	}

    void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
		transform.LookAt(target);
	}


	private void CheckForCollision()
	{
		p1 = target.transform.position;
		p2 = transform.TransformPoint(originalCamPos);
		RaycastHit hit = new RaycastHit();
		if (Physics.Linecast(p1, p2, out hit))
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
