using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SniffTrail : MonoBehaviour
{
	[SerializeField] ParticleSystem _particle;
	NavMeshAgent _agent;
	DogGraphics _dogGraphics;


	public Transform Objective { get; set; }

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

		_particle.Stop();
		_agent.SetDestination(Objective.position);
		_particle.Play();

	}
}