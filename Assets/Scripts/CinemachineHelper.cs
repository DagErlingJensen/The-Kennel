using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineHelper : MonoBehaviour
{
	[SerializeField] Transform _dog;
	CinemachineVirtualCamera _virtualCamera;
	CinemachineTransposer _transposer;

	private void Awake()
	{
		_virtualCamera = GetComponent<CinemachineVirtualCamera>();
		_transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

	}

	private void Update()
	{
		float angle = Vector3.Angle(transform.forward, _dog.forward);
		_transposer.m_YawDamping = 5 / (angle / 50);
	}
}