using UnityEngine;

public class CameraTarget : MonoBehaviour
{
	[SerializeField] private Transform _followTarget;


	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, _followTarget.position, Time.deltaTime * 3);
	}
}