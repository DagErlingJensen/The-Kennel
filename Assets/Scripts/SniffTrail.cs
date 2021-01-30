using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SniffTrail : MonoBehaviour
{
	[SerializeField] Transform _objective;
	NavMeshAgent _agent;
	DogGraphics _dogGraphics;
	[SerializeField] TrailRenderer _trailRenderer;

	private void Awake()
	{
		_agent = GetComponent<NavMeshAgent>();
	}

	private void Start()
	{
		_dogGraphics = FindObjectOfType<DogGraphics>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			Sniff();
		}
	}

	void Sniff()
	{
		if (_dogGraphics == null) return;


		NavMeshHit hit;
		NavMesh.SamplePosition(_dogGraphics.transform.position, out hit, 10, NavMesh.AllAreas);
		_agent.Warp(hit.position);

		_trailRenderer.Clear();

		_agent.SetDestination(_objective.position);
	}
}