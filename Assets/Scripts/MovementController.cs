using UnityEngine;

public class MovementController : MonoBehaviour
{
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _airborneSpeedMultiplier;
	[SerializeField] private float _jumpHeight;
	[SerializeField] private float _jumpLength;
	[SerializeField] private float _stepHeight;
	[SerializeField] private LayerMask _ignoreLayer;
	[SerializeField] private Camera _camera;

	private Rigidbody _rigidbody;
	private CapsuleCollider _capsuleCollider;
	private Vector3 _inputDirection;
	private Vector3 _moveDirection;
	private Vector3 _moveVelocity;
	private Vector3 _airborneMoveVelocity;
	private Vector3 _colliderCenter;
	private RaycastHit _hit;
	DogGrounding _dogGrounding;
	private Vector3 boxExtents = new Vector3(0.4f, 0.1f, 0.4f);
	public Vector3 MoveDirection { get => _moveDirection; }
	public Vector3 GroundNormal { get; private set; }

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_capsuleCollider = GetComponent<CapsuleCollider>();
		_dogGrounding = GetComponent<DogGrounding>();
		_ignoreLayer = ~_ignoreLayer;
		Camera.main.transform.parent = null; 
	}



	private void Update()
	{
		_inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		_inputDirection = Camera.main.transform.TransformDirection(_inputDirection);
		Debug.DrawRay(transform.position, _inputDirection * 4.1f, Color.red);

		if (_inputDirection.magnitude < 0.2f)
		{
			_moveDirection = Vector3.zero;
			return;
		}

		_colliderCenter = transform.TransformPoint(_capsuleCollider.center);

		transform.rotation = Quaternion.LookRotation(_moveDirection);

		HandleMovement();

		Debug.DrawRay(transform.position, _moveDirection * 5.1f, Color.green);

	}

	void HandleMovement()
	{


		if (RaycastHittingGround())
		{
			MoveParallelToGround();
			Debug.Log("hitting ground");

		}
		else
		{
			MoveAirborne();
			Debug.Log("airborne");
		}
	}

	private void MoveParallelToWall()
	{
		Vector3 crossedDirection = Vector3.Cross(_inputDirection, _hit.normal);
		Vector3 parrallelDirection = Vector3.Cross(_hit.normal, crossedDirection);
		parrallelDirection.y = 0;
		_moveDirection = parrallelDirection;
	}

	private void MoveParallelToGround()
	{
		Vector3 crossedDirection = Vector3.Cross(_inputDirection, _hit.normal);
		_moveDirection = Vector3.SmoothDamp(_moveDirection, Vector3.Cross(_hit.normal, crossedDirection), ref _moveVelocity, 0.1f);
	}

	private void MoveAirborne()
	{
		_moveDirection = Vector3.SmoothDamp(_moveDirection, _inputDirection * _airborneSpeedMultiplier, ref _airborneMoveVelocity, 0.4f);
	}

	private bool RaycastHittingGround()
	{

		if (Physics.Raycast(_colliderCenter, -transform.up, out _hit, 1, _ignoreLayer))
		{
			if (_hit.collider.isTrigger)
			{
				GroundNormal = _hit.normal;
				return false;
			}
			else return true;
			
		}
		return false;
	}

	private bool InputDirectionIntoWall()
	{
		if (Physics.BoxCast(transform.position + (transform.up * _stepHeight), boxExtents, _inputDirection, out _hit, Quaternion.LookRotation(_inputDirection), 1.1f, _ignoreLayer))
		{
			if (_hit.collider.isTrigger) return false;
			else return true;
		}
		return false;
	}

	private bool MoveDirectionIntoWall()
	{
		if (Physics.Raycast(transform.position + (transform.up * (_stepHeight + 0.1f)), _moveDirection, out _hit, _capsuleCollider.radius * 1.1f, _ignoreLayer))
		{
			if (_hit.collider.isTrigger) return false;
			else return true;
		}
		return false;
	}

	private void FixedUpdate()
	{
		if (!MoveDirectionIntoWall())
			_rigidbody.MovePosition(transform.position + _moveDirection * Time.deltaTime * _runSpeed);
	}
}