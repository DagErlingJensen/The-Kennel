using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    public int pickUps;

    public DoorController doorUnlock;
    void Start()
    {
        //pickUps = 0;

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUps++;
            Debug.Log("Picked Up" + pickUps);
        }
        if (pickUps >= 3)
        {
            doorUnlock.openDoor = true;
        }

    }
}
