﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offset;
	public Vector3 rotationVector;


    void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
		transform.LookAt(target, rotationVector);
	}
}
