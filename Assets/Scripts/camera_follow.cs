using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform carTransform;
	[Header("Follow")]
	[Range(1, 10)] public float followSpeed = 5f;
	public float distance = 6f;
	public float heightOffset = 2f;

	[Header("Collision")]
	public float collisionRadius = 0.3f;
	public float minDistance = 1.5f;
	public LayerMask collisionLayers = ~0;

	[Header("Mouse control")]
	[Range(0.1f, 10f)] public float mouseSensitivity = 3f;
	public float minVerticalAngle = -30f;
	public float maxVerticalAngle = 60f;
	public bool lockAndHideCursor = true;

	float _yaw;
	float _pitch;

	void Start(){
		if (carTransform == null)
		{
			Debug.LogError("[CameraFollow] carTransform is not assigned");
			enabled = false;
			return;
		}

		Vector3 offset = transform.position - (carTransform.position + Vector3.up * heightOffset);
		if (offset.sqrMagnitude > 0.0001f)
		{
			distance = offset.magnitude;
			Vector3 dir = offset.normalized;
			_yaw = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
			_pitch = Mathf.Asin(dir.y) * Mathf.Rad2Deg;
		}

		if (lockAndHideCursor)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	void FixedUpdate()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = Input.GetAxis("Mouse Y");

		_yaw += mouseX * mouseSensitivity;
		_pitch -= mouseY * mouseSensitivity;
		_pitch = Mathf.Clamp(_pitch, minVerticalAngle, maxVerticalAngle);

		Quaternion rot = Quaternion.Euler(_pitch, _yaw, 0f);
		Vector3 desiredOffset = rot * new Vector3(0f, 0f, -distance);
		Vector3 targetPos = carTransform.position + Vector3.up * heightOffset;
		Vector3 desiredPos = targetPos + desiredOffset;

		Vector3 dir = (desiredPos - targetPos).normalized;
		float targetDistance = distance;
		RaycastHit hit;
		if (Physics.SphereCast(targetPos, collisionRadius, dir, out hit, distance, collisionLayers, QueryTriggerInteraction.Ignore))
		{
			targetDistance = Mathf.Max(minDistance, hit.distance - collisionRadius);
		}
		Vector3 finalPos = targetPos + dir * targetDistance;

		transform.position = Vector3.Lerp(transform.position, finalPos, followSpeed * Time.deltaTime);

		transform.rotation = Quaternion.LookRotation(targetPos - transform.position, Vector3.up);
	}

}
