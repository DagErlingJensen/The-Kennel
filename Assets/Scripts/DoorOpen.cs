using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public DoorController doorControllerScript;
    void Start()
    {
        doorControllerScript = GameObject.Find("Door").GetComponent<DoorController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            doorControllerScript.openDoor = true;
            Debug.Log("Door Open");
        }
    }
}
