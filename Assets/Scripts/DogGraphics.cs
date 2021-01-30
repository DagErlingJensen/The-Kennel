using UnityEngine;

public class DogGraphics : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private GameObject graphicsGameObject;
	private MovementController _movementController;

	Vector3 _rotateVelocity;

	private void Awake()
	{
		_movementController = GetComponent<MovementController>();
	}

	private void Update()
	{
		_animator.SetFloat("Speed_f", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))) * 0.98f);

		if (_movementController.MoveDirection.magnitude < 0.4f) return;



		float angle = Vector3.Angle(graphicsGameObject.transform.forward, _movementController.MoveDirection);

		if(angle > 150)
		{
			graphicsGameObject.transform.rotation = Quaternion.LookRotation(_movementController.MoveDirection);
		}
		else
		{
			graphicsGameObject.transform.rotation = Quaternion.LookRotation(Vector3.SmoothDamp(graphicsGameObject.transform.forward, _movementController.MoveDirection, ref _rotateVelocity, 0.2f));
		}

	}
}