using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Pickup : MonoBehaviour
{
    public Transform[] lastPickUpLocations = new Transform[4];

    public GameObject lastPickup;
    void Awake()
    {
        int variable = Random.Range(0, lastPickUpLocations.Length -1);
        Instantiate(lastPickup, lastPickUpLocations[variable].position, lastPickUpLocations[variable].rotation);
    }
    void Update()
    {
        Debug.Log(lastPickup.transform.position);
    }
}
