using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnim;

    public bool openDoor = false;
    
    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (openDoor == true)
        {
            doorAnim.SetBool("OpenDoor", true);
        }
               
    }
}
