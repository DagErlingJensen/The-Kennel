using UnityEngine;
using UnityEngine.Events;

public class DogJump : MonoBehaviour
{
	[SerializeField] private float _jumpForce;

	private Rigidbody _rigidbody;
	private CapsuleCollider _collider;
	private DogGrounding _dogGrounding;
	private RaycastHit _hit;
	public float TimeSinceLastJump { get; private set; }

	public UnityEvent OnJump;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_collider = GetComponent<CapsuleCollider>();
		_dogGrounding = GetComponent<DogGrounding>();
	}

	private void Update()
	{
		TimeSinceLastJump += Time.deltaTime;
		Jump();
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") == false || TimeSinceLastJump < 0.3f) return;
		if (_dogGrounding.IsGrounded == false && _dogGrounding.TimeSinceLastGrounded > 0.4f) return;

		Ray ray = new Ray(transform.position, -transform.up * 0.6f);

		Debug.DrawRay(transform.position, -transform.up * 0.6f, Color.black, 3);
		if (Physics.SphereCast(transform.position, 0.4f, -transform.up, out _hit, 10))
		{
			OnJump?.Invoke();
			_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
			_rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
			TimeSinceLastJump = 0;
		}
	}
}
