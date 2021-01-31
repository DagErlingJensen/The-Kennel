using UnityEngine;

public class SniffTrailSpawner : MonoBehaviour
{
	[SerializeField] private SniffTrail _trailPrefab;

	private void Start()
	{
		GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");

		foreach (GameObject pickup in pickups)
		{
			SniffTrail sniffTrail = Instantiate(_trailPrefab);
			sniffTrail.Objective = pickup.transform;
		}
	}
}