using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DogGrounding : MonoBehaviour
{
	[SerializeField] private LayerMask _ignoreLayers;
	private CapsuleCollider _collider;
	private RaycastHit _hit;

	public bool IsGrounded { get; private set; } = true;
	public float TimeSinceLastGrounded { get; private set; }

	public UnityEvent OnLand;

	private void Awake()
	{
		_collider = GetComponent<CapsuleCollider>();
		_ignoreLayers = ~_ignoreLayers;
	}

	private void Update()
	{
		Vector3 colliderCenter = transform.TransformPoint(_collider.center);
		Debug.DrawRay(colliderCenter, -transform.up * (_collider.height * 0.3f), Color.green);

		if (Physics.SphereCast(colliderCenter, _collider.radius * 0.9f, -transform.up, out _hit, (_collider.height * 0.3f), _ignoreLayers))
		{
			if (IsGrounded == false)
			{
				OnLand?.Invoke();
			}
			IsGrounded = true;
			TimeSinceLastGrounded = 0;
		}
		else
		{
			IsGrounded = false;
			TimeSinceLastGrounded += Time.deltaTime;
		}
	}
}
