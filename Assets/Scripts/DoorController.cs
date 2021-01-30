using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimRight;
    public Animator doorAnimLeft;

    public bool openDoor = false;
    

    // Update is called once per frame
    void Update()
    {
        if (openDoor == true)
        {
            doorAnimLeft.SetBool("OpenDoor", true);
            doorAnimRight.SetBool("OpenDoor", true);
        }

    }
}
