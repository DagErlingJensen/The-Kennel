using UnityEngine;

public class DogGraphics : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private GameObject graphicsGameObject;
	private MovementController _movementController;

	private void Awake()
	{
		_movementController = GetComponent<MovementController>();
	}

	private void Update()
	{
		_animator.SetFloat("Speed_f", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))) * 0.98f);
		if(_movementController.MoveDirection.magnitude > 0.4f)
		graphicsGameObject.transform.rotation = Quaternion.LookRotation(_movementController.MoveDirection);
	}
}