using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Pickup : MonoBehaviour
{
    public Transform[] lastPickUpLocations = new Transform[4];

    public GameObject lastPickup;
    void Awake()
    {
        int variable = Random.Range(0, lastPickUpLocations.Length);
        Instantiate(lastPickup, lastPickUpLocations[variable-1].position, lastPickUpLocations[variable-1].rotation);
    }
    void Update()
    {
        Debug.Log(lastPickup.transform.position);
    }
}
