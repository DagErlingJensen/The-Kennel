using UnityEngine;

public class DogGraphics : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private GameObject graphicsGameObject;
	private MovementController _movementController;
	DogJump _dogJump;
	DogGrounding _dogGrounding;

	Vector3 _rotateVelocity;

	private void Awake()
	{
		_movementController = GetComponent<MovementController>();
		_dogJump = GetComponent<DogJump>();
		_dogGrounding = GetComponent<DogGrounding>();
		_dogJump.OnJump.AddListener(Jump);
		_dogGrounding.OnLand.AddListener(Land);
	}

	private void Update()
	{
		_animator.SetFloat("Speed_f", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))) * 0.98f);
	}

	void Jump()
	{
		_animator.ResetTrigger("Land");
		_animator.SetTrigger("Jump");
	}

	void Land()
	{
		_animator.SetTrigger("Land");
		Debug.Log("Land");

	}
}