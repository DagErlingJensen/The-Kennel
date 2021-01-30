using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] Transform _followTarget;
	[SerializeField] float _followTime;
	[SerializeField] float _rotateTime;

	Vector3 _offset;
	Vector3 _followVelocity;
	Vector3 _rotateVelocity;

	private void Awake()
	{
		_offset = _followTarget.TransformPoint(transform.position);
	}

	private void FixedUpdate()
	{
		transform.position = Vector3.SmoothDamp(transform.position, _followTarget.TransformPoint(_offset), ref _followVelocity, _followTime);
		transform.rotation = Quaternion.LookRotation(Vector3.SmoothDamp(transform.forward, _followTarget.forward, ref _rotateVelocity, _rotateTime));
	}
}